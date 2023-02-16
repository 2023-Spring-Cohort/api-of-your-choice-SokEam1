using EldenRing.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

namespace EldenRingTutorial.Context
{
    public class GameContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server = (localdb)\\mssqllocaldb; Database =GameTesting; Trusted_Connection = True; ";
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Character> Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>().HasData(
                new Character { Id = 1, Name = "Elden Beast", Area = "Lands Between" },
                new Character { Id = 2, Name = "Blaidd", Area = "Limgrave" },
                new Character { Id = 3, Name = "Malenia", Area = "Sofria" });
        }
    }
}
