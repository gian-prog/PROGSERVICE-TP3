using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DbSet<TP3__FlappyBirb.Models.Scores> Scores { get; set; } = default!;
    }
}
