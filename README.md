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
