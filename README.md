# GymApp

[Demo Link](https://youtu.be/yourDemoVideoLink)

## Project Description

ymApp is a .NET Core 8 web application designed to manage the daily operations of health and fitness clubs. It provides tools for member and session management, booking classes, tracking equipment maintenance, and processing payments, all within a user-friendly interface.

## Application Functions

GymApp enhances the management of a fitness facility with several key functionalities:
- **Member Management**: Comprehensive handling of member profiles, including creation, modification, and deletion.
- **Class Scheduling**: Tools for planning and updating group fitness classes, with capabilities to manage attendance and schedules.
- **Personal Training Management**: Facilitates the scheduling and management of personal training sessions.
- **Equipment Maintenance**: Logs and schedules maintenance tasks for gym equipment to ensure optimal operation.
- **Payment Processing**: Secure processing of payments for memberships, services, and classes.
- **Reporting and Analytics**: Generates reports on gym usage, financials, and member engagement to aid strategic planning.

## System Requirements

- Visual Studio 2022 Community Edition
- .NET Core 8 SDK
- PostgreSQL Database
- Entity Framework Core 8.0.4

## Project Structure

### `/Controllers`
Contains C# files that handle HTTP requests, interacting with models to process data and send it to views.

### `/Models`
Includes classes representing data models that correspond to database tables.

### `/Views`
Holds Razor view files (.cshtml files) that generate the HTML content sent to the client.

### `/wwwroot`
This directory stores static assets such as CSS, JavaScript, and image files used across the application.

### `/appsettings.json`
Configuration file with database connection strings and other settings.

### `/Migrations`
Contains Entity Framework migration files that manage database schema versions and updates.

## Installation and Usage Instructions

1. **Database Setup**:
    - Start PostgreSQL and establish a new database titled `gym`.
    - Adjust the connection string in `appsettings.json` to match your database credentials:
      ```json
      "ConnectionStrings": {
        "GymDB": "Server=localhost;Database=gym;Port=5432;User Id=postgres; Password=your_password"
      }
      ```

2. **Entity Framework Migrations**:
    - In Visual Studio, navigate to `Tools > Command Line > Developer PowerShell`.
    - Verify Entity Framework installation with `dotnet ef`.
    - If not installed, execute `dotnet tool install --global dotnet-ef`.
    - Run `dotnet ef database update` to implement migrations and configure the database schema.

3. **Application Execution**:
    - Open the solution in Visual Studio.
    - Build the project to restore necessary packages.
    - Launch the application using IIS Express.
    - Open a web browser and go to the displayed localhost URL to interact with GymApp.

## Considerations and Limitations

- **Scheduling Conflicts**: The current design does not prevent overlapping bookings for rooms or sessions. Implementing additional logic or constraints to check for conflicts during booking could help prevent these issues.
- **Data Validation**: The schema lacks CHECK constraints that are necessary for validating data upon entry. For example, ensuring that `weight_goal_end_kg` is greater than `weight_goal_start_kg`. Incorporating these constraints will help maintain logical consistency in the database.
- **Cascade Rules**: Currently, the database does not implement cascade rules for foreign key relationships. Adding ON DELETE and ON UPDATE CASCADE rules will ensure that deletions or updates maintain referential integrity.
- **Normalization and Redundancy**: The separation of sessions and classes as distinct entities, although treated as types of bookings, could be revisited to reduce redundancy and integrate these concepts more closely.
