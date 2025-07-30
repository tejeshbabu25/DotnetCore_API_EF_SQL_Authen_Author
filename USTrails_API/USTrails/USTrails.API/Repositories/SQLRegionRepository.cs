using Microsoft.EntityFrameworkCore;
using USTrails.API.Data;
using USTrails.API.Models.Domain;

namespace USTrails.API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly USTrailsDbContext dbContext;

        public SQLRegionRepository(USTrailsDbContext uSTrailsDbContext)
        {
            this.dbContext = uSTrailsDbContext;
        }
        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }
    }
}
