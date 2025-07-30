using USTrails.API.Models.Domain;

namespace USTrails.API.Repositories
{
    public class InMemoryRegionRepository : IRegionRepository
    {
        public async Task<List<Region>> GetAllAsync()
        {
            return new List<Region>
            {
                new Region() 
                {
                 Id = Guid.NewGuid(),
                 Code = "ABC",
                 Name="Como Park",
                 RegionImageUrl = "Como-park.jpg"

                }
            };
        }
    }
}
