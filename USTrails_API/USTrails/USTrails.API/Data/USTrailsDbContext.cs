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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed data for difficulties
            // Easy, Medium , Hard

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("3e7358f8-08cd-4eca-b05e-ee397065e0d9"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("834f014b-2e45-4a9f-adad-6a233e63e7d6"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("b30b93bc-0e7c-435d-b1d9-7c7d2f118570"),
                    Name = "Hard"
                },
            };

            // this will Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            var regions = new List<Region>() {
             new Region()
             {
                 Id = Guid.Parse("a4bd69b1-e24b-4c1d-8d31-247faa21be76"),
                 Name = "New Hampshire",
                 Code = "NHR",
                 RegionImageUrl = "new.hampshire.jpg"
             },
             new Region()
             {
                 Id = Guid.Parse("7b23c14f-d27d-4923-af69-90e15b0b3b62"),
                 Name = "Vermont",
                 Code = "VER",
                 RegionImageUrl = null
             },
             new Region()
             {
                 Id = Guid.Parse("7b0c0ffd-c98a-4164-b9f6-74193b04b50b"),
                 Name = "Utah",
                 Code = "UHR",
                 RegionImageUrl = "Utah.jpg"
             },
              new Region()
             {
                 Id = Guid.Parse("7f8c1664-ce24-4c8a-ab23-645edc9d0eeb"),
                 Name = "California",
                 Code = "CAR",
                 RegionImageUrl = null
             }

            };

            modelBuilder.Entity<Region>().HasData(regions);
        }

    }
}
