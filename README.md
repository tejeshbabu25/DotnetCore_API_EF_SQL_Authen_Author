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
-- api/regions
-- api/regions/{id}
-- POST : api/regions
-- PUT : api/regions/{id}
-- DELETE : api/regions/{id}

# DTOs and Domain Models
- DTOs are Data transfer options
- used to transfer data between different layers
- contain a subset of the properties in the domain model - eg to transfer data over the network
- order of data transfer is as below
- Client -> DTOs -> API -> Domain Model -> Database
- As you can see , we always send DTO's to the client, not the domain model
- Also we can decide what we want to expose to user instead of all properties in domain model
- Using DTO's decouples the domain models from view layer of API

# Advantages of DTOs
- Separation of concern
- Peformance
- Security
- Versioning

# Asynchronous Programming
- in a tranditional synchronous programing - program executon is blocked, leading to poor performance
- So , we use Asynchronous Programming using Async/await keywords and wrapping return type Task keyword
