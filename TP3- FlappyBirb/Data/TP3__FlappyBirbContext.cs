using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TP3__FlappyBirb.Models;

namespace TP3__FlappyBirb.Data
{
    public class TP3__FlappyBirbContext : IdentityDbContext<User>
    {
        public TP3__FlappyBirbContext (DbContextOptions<TP3__FlappyBirbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            PasswordHasher<User> hasher = new PasswordHasher<User>();
            User u1 = new User
            {
                Id = "11111111-1111-1111-1111-111111111111", // Format GUID
                UserName = "Maxime22",
                Email = "maxime@gmail.com",
                NormalizedEmail = "MAXIME@GMAIL.COM",
                NormalizedUserName = "MAXIME22"
                
            };
            u1.PasswordHash = hasher.HashPassword(u1, "Salut1!");
            builder.Entity<User>().HasData(u1);
            builder.Entity<Scores>().HasData(new
            {
                Id = 1,
                Score = 1000,
                Temps = 120.00,
                Date = DateTime.Now,
                Visibilite = true,
                userId = "11111111-1111-1111-1111-111111111111"
            }, new
            {
                Id = 2,
                Score = 800,
                Temps = 60.00,
                Date = DateTime.Now,
                Visibilite = false,
                userId = "11111111-1111-1111-1111-111111111111"
            });

            User u2 = new User
            {
                Id = "11111111-1111-1111-1111-111111111112", 
                UserName = "Maximus23",
                Email = "maximus@gmail.com",
                NormalizedEmail = "MAXIMUS@GMAIL.COM",
                NormalizedUserName = "MAXIMUS23"

            };
            u2.PasswordHash = hasher.HashPassword(u2, "Salut1!");
            builder.Entity<User>().HasData(u2);
            builder.Entity<Scores>().HasData(new
            {
                Id = 3,
                Score = 400,
                Temps = 200.00,
                Date = DateTime.Now,
                Visibilite = true,
                userId = "11111111-1111-1111-1111-111111111112"
            }, new
            {
                Id = 4,
                Score = 34,
                Temps = 5.00,
                Date = DateTime.Now,
                Visibilite = false,
                userId = "11111111-1111-1111-1111-111111111112"
            });

        }
        public DbSet<TP3__FlappyBirb.Models.Scores> Scores { get; set; } = default!;
    }
}
