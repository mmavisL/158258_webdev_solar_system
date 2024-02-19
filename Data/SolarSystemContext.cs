using _14068570___Solar_System.Models;
using System.Data.Entity;

namespace _14068570___Solar_System.Data
{
    public class SolarSystemContext : DbContext
    {
        public SolarSystemContext():base("SolarSystem")
        {
            
        }

        public DbSet<Planet> Planets { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}