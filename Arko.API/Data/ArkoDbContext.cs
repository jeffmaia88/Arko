using Arko.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Arko.API.Data
{
    public class ArkoDbContext : DbContext
    {
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Analyst> Analysts { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Exit> Exists { get; set; }
        public DbSet<CurrentStock> CurrentStocks { get; set; }
        public DbSet<Discharge> Discharges { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArkoDbContext).Assembly);
        }

    }
}
