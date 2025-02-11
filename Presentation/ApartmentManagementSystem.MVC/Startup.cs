﻿using ApartmentManagementSystem.Domain.Entities;
using ApartmentManagementSystem.Persistance;
using ApartmentManagementSystem.Persistance.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Resend;

namespace ApartmentManagementSystem.MVC
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<ApartmentManagementSystemDbContext>(options =>
            {
                options.UseNpgsql(Configurations.GetString("ConnectionStrings:PostgreSQL"));
            });
            services.AddIdentity<AppUser, AppRole>()
            .AddEntityFrameworkStores<ApartmentManagementSystemDbContext>().AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(opt =>
            {
                var cookieBuilder = new CookieBuilder();
                cookieBuilder.Name = "ApartmentManagementCookies";
                opt.LoginPath = new PathString("/auth/signin");
                opt.LogoutPath = new PathString("/member/signout");
                opt.AccessDeniedPath = new PathString("/member/accessdenied");
                opt.Cookie = cookieBuilder;
                opt.ExpireTimeSpan = TimeSpan.FromDays(1);
                opt.SlidingExpiration = true;

            });
            services.Configure<IdentityOptions>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
            });
            services.AddHttpClient<ResendClient>();
            services.Configure<ResendClientOptions>(o =>
            {
                o.ApiToken = "re_QFpas975_BaWB3Ddhe9svDboxmhAeQABK";
            });
            services.AddTransient<IResend, ResendClient>();
            services.AddMvc(options => options.EnableEndpointRouting = false).AddNToastNotifyToastr();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policy =>
                {
                    policy.RequireRole("Admin");
                });

                options.AddPolicy("UserPolicy", policy =>
                {
                    policy.RequireRole("User");
                });

            });
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Session süresi ayarlanabilir
            });
            services.AddHttpContextAccessor();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseNToastNotify();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areaRoute",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=AddDaires}/{action=Add}");

              
            });
        }
    }
}

