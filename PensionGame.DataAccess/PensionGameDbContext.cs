using Microsoft.EntityFrameworkCore;
using PensionGame.DataAccess.Data_Objects.GameData;
using PensionGame.DataAccess.Data_Objects.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.DataAccess
{
    public class PensionGameDbContext : DbContext
    {
        public PensionGameDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Session>? Sessions { get; set; }
        public DbSet<GameState>? GameStates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Session>().HasIndex(s => s.Id).IsUnique();
        }
    }
}
