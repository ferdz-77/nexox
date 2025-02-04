using Microsoft.EntityFrameworkCore;
using Nexox.Models;

namespace nexox.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Artist> Artists { get; set; }

        public DbSet<Artwork> Artworks { get; set; }
    }
}