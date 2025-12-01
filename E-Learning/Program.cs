using E_Learning.Extensions;
using E_Learning.Infrastructure.Persistence;
using E_Learning.Mappings;
using E_Learning.Mappings.ListeningMappings;
using E_Learning.Mappings.ReadingMappings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
Console.WriteLine($"Environment: {builder.Environment.EnvironmentName}");

builder.Services
    .AddAppDbContext(builder.Configuration)
    .AddIdentityServices()
    .AddApplicationServices()
    .AddWebServices()
    .AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

app.UseWebMiddleware();
app.Run();
