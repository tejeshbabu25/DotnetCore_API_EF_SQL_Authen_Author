using USTrails.API.Models.Domain;

namespace USTrails.API.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();


    }
}
