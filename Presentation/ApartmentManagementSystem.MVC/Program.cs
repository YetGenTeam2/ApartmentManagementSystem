using ApartmentManagementSystem.Domain.Entities;
using ApartmentManagementSystem.Persistance;
using ApartmentManagementSystem.Persistance.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Resend;
using ApartmentManagementSystem.MVC;
using ApartmentManagementSystem.MVC.Services;
using Sotsera.Blazor.Toaster.Core.Models;

var builder = WebApplication.CreateBuilder(args);

// ConfigureServices metodu için Startup sýnýfýný kullan
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

builder.Services.AddScoped<IToasterService, SotseraToastService>();

builder.Services.AddToaster(config =>
{
    //example customizations
    config.PositionClass = Defaults.Classes.Position.TopRight;
    config.PreventDuplicates = true;
    config.NewestOnTop = false;
});

var app = builder.Build();

// Configure metodu için Startup sýnýfýný kullan
startup.Configure(app, builder.Environment);

app.Run();