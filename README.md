# DotnetCore_API_EF_SQL_Authen_Author
Use C# and Build an ASP.NET Core Web API with Entity Framework Core, SQL Server, Authentication, Authorization | .NET8

# DbContext Class
- Maintaining Connection to database
- Track Changes
- Perform CRUD Operations
- Acts as a bridge between domain models and the database

# Dependency Injection
- DI is build into ASP.NET Core
- responsible for creating and managing instances
- provides greater maintainabiity
- and also testability
- classes are injected into program.cs class for instantiating
- for eg., services.AddScoped<IMyServices,MyServices>();

# Adding EF Core Migrations
- open Nuget manager console, run below commands
- Add-Migration "Intitial Migration" -- to add initial migrations -- and it adds a new Migrations folder to the solution
- Update-Database -- reads the migrations created in above step and creates the Db on SQL Server

# Create a new Controller and Endpoints for Regions domain
- GET/PUT/POST/DELETE

