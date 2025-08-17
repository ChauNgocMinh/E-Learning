using E_Learning.Extensions;
using E_Learning.Infrastructure.Persistence;
using E_Learning.Mappings;
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
