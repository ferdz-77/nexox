using Nexox.DTOs;
using Nexox.Models;

namespace Nexox.Services
{
    public interface IArtworkService
    {
        Task<IEnumerable<ArtworkDTO>> GetAllAsync();
        Task<ArtworkDTO> GetByIdAsync(int id);
        // Task AddAsync(ArtworkDTO artworkDto);
        Task<ArtworkDTO> AddAsync(ArtworkDTO artworkDto);
        Task UpdateAsync(int id, ArtworkDTO artworkDto);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();

    }
}
