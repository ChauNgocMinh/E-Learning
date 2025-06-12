using Ecommerce_Project.Extensions;
using Ecommerce_Project.Infrastructure.Persistence;
using Ecommerce_Project.Mappings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
Console.WriteLine($"Environment: {builder.Environment.EnvironmentName}");

builder.Services
    .AddAppDbContext(builder.Configuration)
    .AddIdentityServices()
    .AddApplicationServices()
    .AddWebServices()
    .AddMappingProfiles();

var app = builder.Build();

app.UseWebMiddleware();
app.Run();
