using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace ApartmentManagementSystem.Persistance.Context
{
    public class ApartmentManagementSystemDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        

        public ApartmentManagementSystemDbContext(DbContextOptions<ApartmentManagementSystemDbContext> options) : base(options)
        {

        }
        public ApartmentManagementSystemDbContext() { }
        DbSet<Daire> daires { get; set; }

        DbSet<Subscription> subscriptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configurations.GetString("ConnectionStrings:PostgreSQL"));
        }
    }
}
