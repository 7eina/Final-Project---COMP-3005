# GymApp

## Demo Link

**Note to Viewer**

- Please excuse any interface inconsistencies; the demo is recorded under development settings.
- Light mode interface showcased.

## Project Description
GymApp is a comprehensive web application developed using .NET Core 8 and C#, integrated with a PostgreSQL database. This application serves to manage the operations of a health and fitness club, including member management, class scheduling, and equipment maintenance.

## Application Functions
The GymApp provides a dynamic web interface for gym staff and members to perform a variety of tasks:
- **Member Management**: Add, update, view, and delete member information.
- **Class Management**: Schedule, update, and manage fitness classes.
- **Equipment Tracking**: Log equipment usage and schedule maintenance.
- **Payment Processing**: Handle membership and service billing.

## System Requirements
- Visual Studio 2022 Community Edition
- .NET Core 8 SDK
- PostgreSQL Database
- Entity Framework Core 8.0.4

## Project Structure
The project is structured into several directories, reflecting MVC architecture:

### /Controllers
Contains C# files that handle HTTP requests, interacting with models to process data and send it to views.

### /Models
Includes classes representing data models that correspond to database tables.

### /Views
Holds Razor view files (.cshtml) that generate the HTML content sent to the client.

### /wwwroot
Stores static files like CSS, JavaScript, and images.

### /appsettings.json
Configuration file with database connection strings and other settings.

### /Migrations
Contains Entity Framework migration files for setting up and updating the database schema.

## Installation and Usage Instructions
### Database Setup:
1. **Initialize the Database**:
   - Launch PostgreSQL and create a new database named `gym`.
   - Configure `appsettings.json` with the database connection string:
     ```json
     "ConnectionStrings": {
       "GymDB": "Server=localhost;Database=gym;Port=5432;User Id=postgres; Password=your_password"
     }
     ```

2. **Apply Migrations**:
   - Open Developer PowerShell in Visual Studio via `Tools > Command Line > Developer PowerShell`.
   - Run `dotnet ef database update` to apply migrations and set up the database schema.

### Application Execution:
1. **Open the project in Visual Studio**.
2. **Build the project** to restore packages and prepare the application.
3. **Run the application** using IIS Express from Visual Studio.
4. **Access the web interface** via `http://localhost:port` displayed in Visual Studio.

## Note on Error Handling and Data Validation
- Comprehensive error handling is implemented to manage exceptions related to database interactions and web requests.
- Data validation is enforced both at the model and database levels to ensure data integrity and prevent invalid input.

