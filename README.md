
## Description
This project is a social media platform that allows users to connect, share content, and interact with each other. It provides a dynamic user experience and robust backend services, ensuring secure and efficient operations.
## Technologies Used
- .NET 8
- ASP.NET Core
- Entity Framework Core
- AutoMapper
- SignalR
- Cloudinary (for media storage)

## Key Features
 ### JWT Authentication:
- Secure user authentication and authorization.
 ### Private Messaging:
- Users can send and receive messages privately.
 ### Gallery Management:
- Each user can manage their own gallery to upload and share photos.
 ### Presence Tracking:
- Real-time tracking of user online status.
 ### Likes Between Members:
- Users can like posts and content shared by others.

## Architecture Overview
This project follows the Clean Architecture principles, which separates the application into distinct layers:

- **API Layer**: Contains the controllers that handle HTTP requests and responses.
- **DTOs**: Data Transfer Objects used for data exchange between layers.
- **Data Layer**: Contains the data context, repositories, and migrations for database interactions.
- **Entities**: Domain entities that represent the core data models.
- **Errors**: Custom error handling classes.
- **Extensions**: Extension methods for various functionalities.
- **Helpers**: Utility classes and methods.
- **Interfaces**: Contracts for services and repositories.
- **Middleware**: Custom middleware for handling requests and responses.
- **Services**: Business logic and service implementations.
- **SignalR**: Real-time communication components.

## Installation Instructions
To set up the project locally, follow these steps:

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/yourproject.git
   cd yourproject
   ```

2. Ensure you have the .NET 8 SDK installed. You can download it from [here](https://dotnet.microsoft.com/download/dotnet/8.0).

3. Restore the NuGet packages:
   ```bash
   dotnet restore
   ```

4. Update the `appsettings.Development.json` file with your database connection string and any other necessary configurations.

5. Run the migrations to set up the database:
   ```bash
   dotnet ef database update
   ```

6. Start the application:
   ```bash
   dotnet run
   ```

## Usage
Provide instructions on how to use the application. For example:
- Access the API endpoints via `http://localhost:5000/api/`.
- Use tools like Postman or Swagger to test the API.
- Example endpoints:
  - `POST /api/account/register` - Register a new user.
  - `POST /api/account/login` - Log in a user.
  - `GET /api/users` - Retrieve a list of users.

## Contributing
If you would like to contribute to this project, please follow these steps:
1. Fork the repository.
2. Create a new branch (`git checkout -b feature/YourFeature`).
3. Make your changes and commit them (`git commit -m 'Add some feature'`).
4. Push to the branch (`git push origin feature/YourFeature`).
5. Open a pull request.


## Author
- Rayen Ameur
- Contact me[www.linkedin.com/in/rayen-ameur-10000s000]

