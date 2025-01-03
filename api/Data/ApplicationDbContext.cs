using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Absence> Absences { get; set; }

        // public DbSet<StockComment> Portfolios { get; set; }



        // Seeding database with roles

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // builder.Entity<StockComment>(x => x.HasKey(p => new { p.AppUserId, p.StockId }));

            // builder.Entity<StockComment>()
            //     .HasOne(u => u.AppUser)
            //     .WithMany(u => u.Portfolios)
            //     .HasForeignKey(p => p.AppUserId);

            // builder.Entity<StockComment>()
            //     .HasOne(u => u.Stock)
            //     .WithMany(u => u.Portfolios)
            //     .HasForeignKey(p => p.StockId);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "User", NormalizedName = "USER" }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }

    }
}