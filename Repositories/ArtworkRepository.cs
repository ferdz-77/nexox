using Microsoft.EntityFrameworkCore;
using nexox.Data;
using Nexox.Models;

namespace Nexox.Repositories
{
    public class ArtworkRepository : IArtworkRepository
    {
        private readonly AppDbContext _context;

        public ArtworkRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Artwork>> GetAllAsync()
        {
            return await _context.Artworks.Include(a => a.Artista).ToListAsync();
        }

        public async Task<Artwork> GetByIdAsync(int id)
        {
            return await _context.Artworks.Include(a => a.Artista).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAsync(Artwork artwork)
        {
            await _context.Artworks.AddAsync(artwork);
            await _context.SaveChangesAsync(); // Salva as mudanças após adicionar
        }

        public async Task UpdateAsync(Artwork artwork)
        {
            _context.Artworks.Update(artwork);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var artwork = await _context.Artworks.FindAsync(id);
            if (artwork != null)
            {
                _context.Artworks.Remove(artwork);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
