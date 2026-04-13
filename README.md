# .NET Operations Lab Projects

This repository contains various .NET web applications and database integration projects created as part of the Spring 2026 `.NET` course (Midterm Lab Codes - Lab 1).

## Projects Overview

The repository is divided into two main categories of projects:

1. **WebApplications (`WebApplication1` - `WebApplication5`)**: 
   Basic ASP.NET Core MVC web applications demonstrating various concepts such as MVC architecture, routing, controllers, and view rendering.

2. **Database Applications (`Database_1` - `Database_5`)**: 
   ASP.NET Core MVC applications integrated with Entity Framework (EF) Core for database operations. These projects demonstrate data access approaches (e.g. DbContext configuration, models generation, and CRUD operations).

## Technology Stack

- **Framework**: .NET (ASP.NET Core MVC)
- **Language**: C#
- **ORM**: Entity Framework Core (in Database projects)
- **Database**: SQL Server (Configured via connection strings in `appsettings.json`)

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- Visual Studio 2022, JetBrains Rider, or Visual Studio Code
- SQL Server (for Database projects)

### Running a Project locally

1. **Clone the repository**:
   ```bash
   git clone https://github.com/shamsulalam1114/.net_Operations.git
   cd .net_Operations
   ```

2. **Open a project**:
   Navigate into the specific project folder you want to run (e.g., `cd WebApplication1/WebApplication1`). Alternatively, open the generated `.slnx` solution file in your IDE.

3. **Restore & Build**:
   Build the solution to restore the necessary NuGet packages.
   ```bash
   dotnet build
   ```

4. **Database Configuration** _(Only for `Database_*` projects)_:
   - Make sure your SQL Server connection string is correctly configured in your `appsettings.json` file.
   - Run EF Core database migrations or create the database.
   ```bash
   dotnet ef database update
   ```

5. **Run the Project**:
   Run the project from Visual Studio, or using the CLI command:
   ```bash
   dotnet run
   ```
   The application will start and provide a local URL (e.g., `http://localhost:5xxx` or `https://localhost:7xxx`) that you can open in your browser.

## Repository Structure

```text
.
├── Database_1
├── Database_2
├── Database_3
├── Database_4
├── Database_5
├── WebApplication1
├── WebApplication2
├── WebApplication3
├── WebApplication4
└── WebApplication5
```

## License

This project is licensed under the MIT License - see the LICENSE file for details (if available).
