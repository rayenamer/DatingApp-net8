
🏗️ Architecture Overview
The architecture of an ASP.NET Core 8 API project is organized into distinct layers to promote separation of concerns and maintainability. It includes:

1. Controllers

Responsible for handling incoming HTTP requests and returning responses. Each controller corresponds to a specific resource or functionality, such as user management or messaging.
2. Data Transfer Objects (DTOs)

Used to transfer data between the client and server. DTOs help shape the data sent over the network, ensuring that only necessary information is exposed.
3. Data Layer

Interacts with the database through repositories. This layer encapsulates the logic for accessing data sources, allowing for easy data manipulation and retrieval.
4. Entities

Defines the core business models of the application. Entities represent the data structure and are mapped to the database tables.
5. Error Handling

Manages exceptions and errors that occur during execution, providing a consistent response format for error messages.
6. Middleware

Handles cross-cutting concerns such as logging, authentication, and exception handling, ensuring that these functionalities are applied consistently across the application.
7. Services

Contains business logic and operations that are not directly related to data access. Services interact with repositories and perform operations on the data.
8. SignalR

Enables real-time web functionality, allowing for bi-directional communication between the server and clients.
This layered architecture ensures a clean, maintainable, and scalable application design, making it easier to manage and extend the project as requirements evolve.

📂 Project Structure
The project is organized into several key directories and files:

API
Contains the main API files.

Controllers
AccountController.cs - Manages user account operations.
AdminController.cs - Handles admin-specific operations.
BaseApiController.cs - Base controller for shared functionality.
BuggyController.cs - For testing error handling.
FallBackController.cs - Handles fallback routes.
LikesController.cs - Manages likes on messages.
MessagesController.cs - Handles message operations.
UsersController.cs - Manages user-related operations.
WeatherForecastController.cs - Provides weather forecast data.
DTOs
Data Transfer Objects for the application.

CreateMessageDto.cs - DTO for creating messages.
LoginDto.cs - DTO for user login.
MemberDto.cs - DTO for member information.
MemberUpdateDto.cs - DTO for updating member information.
MessageDto.cs - DTO for message data.
PhotoDto.cs - DTO for photo data.
RegisterDto.cs - DTO for user registration.
User Dto.cs - DTO for user data.
Data
Data access layer.

Migrations - Database migrations.
DataContext.cs - Database context for Entity Framework.
LikesRepository.cs - Repository for likes.
MessageRepository.cs - Repository for messages.
Seed.cs - Database seeding logic.
UnitOfWork.cs - Implements the Unit of Work pattern.
User Repository.cs - Repository for users.
User SeedData.json - Seed data for users.
Entities
Core business models.

AppRole.cs - Represents application roles.
AppUser .cs - Represents application users.
AppUser Role.cs - Represents user-role relationships.
Connection.cs - Represents database connections.
Group.cs - Represents user groups.
Message.cs - Represents messages.
Photo.cs - Represents photos.
User Like.cs - Represents user likes.
Errors
Error handling classes.

ApiExceptions.cs - Custom exceptions for the API.
Extensions
Extension methods for various functionalities.

ApplicationServiceExtensions.cs - Extensions for application services.
ClaimsPrincipleExtensions.cs - Extensions for claims principal.
DateTimeExtensions.cs - Extensions for DateTime operations.
HttpExtensions.cs - Extensions for HTTP operations.
IdentityServiceExtensions.cs - Extensions for identity services.
Helpers
Utility classes and helpers.

AutoMapperProfiles.cs - AutoMapper configuration.
CloudinarySettings.cs - Configuration for Cloudinary.
LikesParams.cs - Parameters for likes.
LogUser Activity.cs - Logs user activity.
MessageParams.cs - Parameters for messages.
PagedList.cs - Implementation of pagination.
PaginationHeader.cs - Contains pagination header information.
PaginationParams.cs .cs - Parameters for pagination.
User Params.cs - Parameters for user queries.
Interfaces
Defines contracts for services and repositories.

ILikesRepository.cs - Interface for likes repository.
IMessageRepository.cs - Interface for message repository.
IPhotoService.cs - Interface for photo service.
ITokenService.cs - Interface for token management.
IUnitOfWork.cs - Interface for unit of work pattern.
IUser Repository.cs - Interface for user repository.
Middleware
Custom middleware components.

ExceptionMiddleware.cs - Middleware for handling exceptions globally.
Properties
Project properties and settings.

launchSettings.json - Configuration for launching the application.
Services
Business logic services.

PhotoService.cs - Service for managing photos.
TokenService.cs - Service for handling token generation and validation.
signalR
Real-time communication components.

MessageHub.cs - Hub for managing message communication.
PresenceHub.cs - Hub for managing user presence.
PresenceTracker.cs - Tracks user presence in real-time.
wwwroot
Static files and assets.

media - Directory for media files.
3rdpartylicenses.txt - Licenses for third-party libraries.
favicon.ico - Favicon for the application.
index.html - Main HTML file.
main-Z3PWW7AI.js - Main JavaScript bundle.
polyfills-FFHMD2TL.js - Polyfills for browser compatibility.
styles-UKQHSZCX.css - Main stylesheet.
API.csproj
Project file for the API.

API.http
HTTP request examples for testing.

Program.cs
Entry point for the application.

WeatherForecast.cs
Model for weather forecast data.

appsettings.Development.json
Configuration settings for development environment.

.gitignore
Files and directories to ignore in version control.

DatingApp.sln
Solution file for the project.

⚙️ Requirements
To run this API project, ensure you have the following installed:

.NET SDK (version 8.0 or higher)
🚀 Usage
Follow these steps to get your API up and running:

Clone the repository:

bash

Verify
Run
Copy code
git clone https://github.com/your-username/api-project.git
cd api-project
Restore dependencies:

bash

Verify
Run
Copy code
dotnet restore
Run the application:

bash

Verify
Run
Copy code
dotnet run
Open your browser or API client and navigate to:


Verify
Run
Copy code
http://localhost:5000/api
Modify configurations as needed in the appsettings.Development.json file.

🤝 Contributing
Contributions are welcome! If you would like to contribute to this project, please follow these steps:

Fork the repository.
Create a new branch:
bash

Verify
Run
Copy code
git checkout -b feature/YourFeatureName
Make your changes and commit them:
bash

Verify
Run
Copy code
git commit -m "Add some feature"
Push to the branch:
bash

Verify
Run
Copy code
git push origin feature/YourFeatureName
Open a pull request.
Please ensure your code adheres to the project's coding standards and includes appropriate tests.

👤 Author
Rayen Ameur
GitHub Profile
LinkedIn Profile

Thank you for checking out the API Project! If you have any questions or feedback, feel free to reach out.

