using Nexox.DTOs;
using Nexox.Models;

namespace Nexox.Repositories
{
    public interface IArtworkRepository
    {
        Task<IEnumerable<Artwork>> GetAllAsync();
        Task<Artwork> GetByIdAsync(int id);
        Task AddAsync(Artwork artwork);
        Task UpdateAsync(Artwork artwork);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
