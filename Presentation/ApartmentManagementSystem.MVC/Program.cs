using ApartmentManagementSystem.Domain.Entities;
using ApartmentManagementSystem.Persistance;
using ApartmentManagementSystem.Persistance.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Resend;
using ApartmentManagementSystem.MVC;

var builder = WebApplication.CreateBuilder(args);

// ConfigureServices metodu i�in Startup s�n�f�n� kullan
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Configure metodu i�in Startup s�n�f�n� kullan
startup.Configure(app, builder.Environment);

app.Run();