using System;
using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class AccountController
(
    DataContext context,
    ITokenService tokenService,
    IMapper mapper
) : BaseApiController
{
    [HttpPost("register")] //account/register
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        if (await UserExists(registerDto.Username))
        {
            
            return Unauthorized("username exist");
        }



       using var hmac = new HMACSHA512();

       var user = mapper.Map<AppUser>(registerDto);

       user.UserName =  registerDto.Username.ToLower();
       user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password));
       user.PasswordSalt = hmac.Key;

       context.Users.Add(user);
       await context.SaveChangesAsync();
       return new UserDto
       {
           UserName = user.UserName,
           Token = tokenService.CreateToken(user),
           KnownAs = user.KnownAs,
           gender = user.Gender,
       };
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        // Fetch the user from the database based on the username
        var user = await context.Users
            .Include(p => p.Photos)
                .FirstOrDefaultAsync(x =>
                    x.UserName == loginDto.Username.ToLower());

        // Return a 401 Unauthorized response if the user does not exist
        if (user == null)
        {
            return Unauthorized("Invalid username");
        }

        // Verify the password using the stored salt and hash
        using var hmac = new HMACSHA512(user.PasswordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

         if (!computedHash.SequenceEqual(user.PasswordHash))
        {
            return Unauthorized("Invalid username or password");
        }

        // Return the user details and the generated token
        return new UserDto
        {
            UserName = user.UserName,
            KnownAs = user.KnownAs,
            Token = tokenService.CreateToken(user),
            PhotoUrl = user.Photos.FirstOrDefault(x => x.IsMain)?.Url,
            gender = user.Gender,
        };
    }


    private async Task<bool> UserExists(string username)
    {
        return await context.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
    }
}
