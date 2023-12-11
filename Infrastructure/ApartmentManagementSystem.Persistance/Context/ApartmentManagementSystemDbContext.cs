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
        DbSet<Daire> daireler { get; set; }

        DbSet<Subscription> subscriptions { get; set; }

        public ApartmentManagementSystemDbContext(DbContextOptions<ApartmentManagementSystemDbContext> options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configurations.GetString("ConnectionStrings:PostgreSQL"));
        }
    }
}
