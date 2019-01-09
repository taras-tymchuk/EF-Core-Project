using EF_Core_Demo.Configurations;
using EF_Core_Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_Demo.Context
{
    public class FootballContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        public FootballContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration( new PlayerConfiguration() );
            modelBuilder.ApplyConfiguration( new TeamConfiguration() );
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder modelBuilder)
        {
            modelBuilder.UseSqlServer( 
                "Server=DESKTOP-I8EO4OE;Database=Football;Trusted_Connection=True" );
        }
    }
}
