using E_Learning.Domain.Entities;
using E_Learning.Extensions;
using E_Learning.Infrastructure.Persistence;
using E_Learning.Mappings;
using E_Learning.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var apiKey = builder.Configuration["OpenAI:ApiKey"];
Console.WriteLine($"Environment: {builder.Environment.EnvironmentName}");

builder.Services

    .AddAppDbContext(builder.Configuration)
    .AddIdentityServices()        
    .AddApplicationServices()
    .AddWebServices()
    .AddAutoMapper(typeof(Program))
    .AddSingleton(new IeltsWritingService(apiKey));
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Auth/Login";
    options.AccessDeniedPath = "/Auth/Login";
});
var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseWebMiddleware();
app.Run();
