using ApartmentManagementSystem.Domain.Entities;
using ApartmentManagementSystem.Persistance;
using ApartmentManagementSystem.Persistance.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Resend;
using ApartmentManagementSystem.MVC;


var builder = WebApplication.CreateBuilder(args);
Startup.ConfigureServices(builder.Services);

var app = builder.Build();
Startup.Configure(app, builder.Environment);

app.Run();
