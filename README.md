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
- also using appropriate methods that support async funtionality like SaveChangesAsync,FirstOrDefaultAsync,AddAsync,FindAsync

# Repository Pattern
- Design Pattern to separate the data access layer from the application
- Provides interface without exposing implementation
- Helps create abstraction
-- ideal flow --> Controller -> Repository(accessed by DbContext) -> Database
-- Benefits
    - Decoupling
    - Consistency
    - Performence
    - Switching multiple data sources

- In our project we created a IRegionRepository with GetAllAsync interface definition
- Then created a SQLRegionRepository class to implement IRegionRepository 
- Then went back controller and injected IRegionRepository in constructor and called the implementation using IRegionRepository method 
- also added builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>(); in program.cs which will ensure everytime a IregionRepository is called,its fed with SQLRegionRepository implementation

- assuming we had to switch datasource from SQLRegionRepository to InMemory datasource,all we have to do is create a InMemoryRegionRepository
- Implement IRegionRepository
- update in program.cs by replacing builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>() with builder.Services.AddScoped<IRegionRepository, InMemoryRegionRepository>();

- Implemeted all methods using Repository Design Pattern

# Automapper
- object to object mapping
- Simplification
- Map DTOs and Domain Models and Vice-versa in ASP.Net Core application
- Install Automapper from Nuget manager
- create mapping profiles
- used AutoMapper.Extensions.Microsoft.DependencyInjection package from nuget
 
# Seeding Data using EntityFramework Core
- from USTrailsDbContext class
- add regions and difficulties to modelbuilder after adding some values to it
- Open Nuget package manager console , run below commands
- 1. Add-Migrations "Seed regions and difficulties"
- 2. Update-Database
- this will push data into regions and difficulties tables on SQL server

# Navigation properties 
- which allow us to navigate from one entity/domain model to another
- eg. trail has difficulty and region as navigation properties
- on the dbcontext method getting data from db, use Include("Difficulty").Include("Region") to get the foreigh key value of the related/navigation tables

# Validations in ASP.NET Core Web API
- Option 1 : 
-  Model Validations using Data Annotations built into ASP.NET Core
- Use annotations like Required,MinLength,Maxlength, Length etc on Model classes
- then in controller use ModelState.IsValid to validate 
- Option 2 :
- using a custom Action filter
- create a new call such as ValidateModelAttribute and override ActionFilterAttribute
- then instead of Model.IsValid lines of code to check, just decorate the controller method with [ValidateModel] attribute