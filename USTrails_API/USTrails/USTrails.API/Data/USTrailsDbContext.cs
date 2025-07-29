using Microsoft.EntityFrameworkCore;
using USTrails.API.Models.Domain;

namespace USTrails.API.Data
{
    public class USTrailsDbContext : DbContext
    {
        public USTrailsDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }

        // DBSet is a property of dbcontext class that represents a collection of entities in the database

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Trail> Trails { get; set; }

    }
}
