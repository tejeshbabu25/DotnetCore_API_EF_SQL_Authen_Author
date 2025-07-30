using Microsoft.EntityFrameworkCore;
using USTrails.API.Data;
using USTrails.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<USTrailsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("USTrailsConnectionString")));
builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>(); // Replace with InMemoryRegionRepository if we have to switch the implementation to InMemory database

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
