using System;
using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class AccountController
(
    UserManager<AppUser> userManager,
    ITokenService tokenService,
    IMapper mapper
) : BaseApiController
{
    [HttpPost("register")] //account/register
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        if (await UserExists(registerDto.Username)) return Unauthorized("username exist");
        

       var user = mapper.Map<AppUser>(registerDto);

       user.UserName =  registerDto.Username.ToLower(); 

       var result = await userManager.CreateAsync(user, registerDto.Password);
       if(!result.Succeeded) return BadRequest(result.Errors);

       return new UserDto
       {
           UserName = user.UserName,
           Token = await tokenService.CreateToken(user),
           KnownAs = user.KnownAs,
           gender = user.Gender,
       };
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        // Fetch the user from the database based on the username
        var user = await userManager.Users
            .Include(p => p.Photos)
                .FirstOrDefaultAsync(x =>
                    x.NormalizedUserName == loginDto.Username.ToUpper());

        // Return a 401 Unauthorized response if the user does not exist
        if (user == null || user.UserName == null)
        {
            return Unauthorized("Invalid username");
        }

        var result = await userManager.CheckPasswordAsync(user, loginDto.Password);
        if(!result) return Unauthorized();

        // Return the user details and the generated token
        return new UserDto
        {
            UserName = user.UserName,
            KnownAs = user.KnownAs,
            Token =await tokenService.CreateToken(user),
            PhotoUrl = user.Photos.FirstOrDefault(x => x.IsMain)?.Url,
            gender = user.Gender,
        };
    }


    private async Task<bool> UserExists(string username)
    {
        return await userManager.Users.AnyAsync(x => x.NormalizedUserName == username.ToUpper());
    }
}
