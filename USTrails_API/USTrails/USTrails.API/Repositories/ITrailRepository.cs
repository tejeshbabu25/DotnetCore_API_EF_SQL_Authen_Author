using USTrails.API.Models.Domain;

namespace USTrails.API.Repositories
{
    public interface ITrailRepository
    {
        Task<Trail> CreateAsync(Trail trail);
        Task<List<Trail>> GetAllAsync();
        Task<Trail?> GetByIdAsync(Guid id);
        Task<Trail?> UpdateAsync(Guid id, Trail trail);
        Task<Trail?> DeleteAsync(Guid id);
    }
}
