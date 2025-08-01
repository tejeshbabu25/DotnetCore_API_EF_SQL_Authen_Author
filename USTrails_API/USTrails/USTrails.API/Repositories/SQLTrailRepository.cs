using Microsoft.EntityFrameworkCore;
using USTrails.API.Data;
using USTrails.API.Models.Domain;

namespace USTrails.API.Repositories
{
    public class SQLTrailRepository : ITrailRepository
    {
        private readonly USTrailsDbContext dbContext;

        public SQLTrailRepository(USTrailsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Trail> CreateAsync(Trail trail)
        {
            await dbContext.Trails.AddAsync(trail);
            await dbContext.SaveChangesAsync();
            return trail;
        }

        public async Task<List<Trail>> GetAllAsync()
        {
            return await dbContext.Trails.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Trail?> GetByIdAsync(Guid id)
        {
            return await dbContext.Trails.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Trail?> UpdateAsync(Guid id, Trail trail)
        {
            var existingTrail = await dbContext.Trails.FirstOrDefaultAsync(x => x.Id == id);
            if (existingTrail == null) { return null; }

            existingTrail.Name = trail.Name;
            existingTrail.Description = trail.Description;
            existingTrail.LengthInMiles = trail.LengthInMiles;
            existingTrail.TrailImageUrl = trail.TrailImageUrl;
            existingTrail.DifficultyId = trail.DifficultyId;
            existingTrail.RegionId = trail.RegionId;

            await dbContext.SaveChangesAsync();
            return existingTrail;
        }

        public async Task<Trail?> DeleteAsync(Guid id)
        {
            var existingTrail = await dbContext.Trails.FirstOrDefaultAsync(x =>x.Id == id);
            if (existingTrail == null) { return null;}

            dbContext.Trails.Remove(existingTrail);
            await dbContext.SaveChangesAsync();
            return existingTrail;
        }
    }
}
