using EF_Core_Demo.Configurations;
using EF_Core_Demo.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

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
            if ( !modelBuilder.IsConfigured )
            {
                string connectionString = ConfigurationManager
                    .ConnectionStrings["connection_string"]
                    .ConnectionString;
                modelBuilder.UseSqlServer( connectionString );
            }
        }
    }
}
