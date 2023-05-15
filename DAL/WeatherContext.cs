using Datalayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Cords> Cordination { get; set; }
        public DbSet<Properties> Properties { get; set; }
        public DbSet<Geometry> Geometries { get; set; }
        public DbSet<Features> Features { get; set; }
        public DbSet<Application> Applications { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = BigData; Trusted_Connection = True; ");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
