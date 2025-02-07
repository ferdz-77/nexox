using Nexox.DTOs;
using Nexox.Models;
using Nexox.Repositories;

namespace Nexox.Services
{
    public class ArtworkService : IArtworkService
    {
        private readonly IArtworkRepository _artworkRepository;

        public ArtworkService(IArtworkRepository artworkRepository)
        {
            _artworkRepository = artworkRepository;
        }

        public async Task<IEnumerable<ArtworkDTO>> GetAllAsync()
        {
            var artworks = await _artworkRepository.GetAllAsync();
            return artworks.Select(a => new ArtworkDTO
            {
                Id = a.Id,
                Titulo = a.Titulo,
                AnoCriacao = a.AnoCriacao,
                Tecnica = a.Tecnica,
                Largura = a.Largura,
                Altura = a.Altura,
                Material = a.Material,
                Preco = a.Preco,
                Imagem = a.Imagem,
                Descricao = a.Descricao,
                Status = a.Status ?? true, // Define TRUE se for NULL
                Localizacao = a.Localizacao,
                Proprietario = a.Proprietario,
                Exposicao = a.Exposicao,
                ArtistaId = a.ArtistaId
            }).ToList();
        }

        public async Task<ArtworkDTO> GetByIdAsync(int id)
        {
            var artwork = await _artworkRepository.GetByIdAsync(id);
            if (artwork == null) return null;

            return new ArtworkDTO
            {
                Id = artwork.Id,
                Titulo = artwork.Titulo,
                AnoCriacao = artwork.AnoCriacao,
                Tecnica = artwork.Tecnica,
                Largura = artwork.Largura,
                Altura = artwork.Altura,
                Material = artwork.Material,
                Preco = artwork.Preco,
                Imagem = artwork.Imagem,
                Descricao = artwork.Descricao,
                Status = artwork.Status ?? true,
                Localizacao = artwork.Localizacao,
                Proprietario = artwork.Proprietario,
                Exposicao = artwork.Exposicao,
                ArtistaId = artwork.ArtistaId
            };
        }

        public async Task<ArtworkDTO> AddAsync(ArtworkDTO artworkDto)
        {
            var artwork = new Artwork
            {
                Titulo = artworkDto.Titulo,
                AnoCriacao = artworkDto.AnoCriacao,
                Tecnica = artworkDto.Tecnica,
                Largura = artworkDto.Largura,
                Altura = artworkDto.Altura,
                Material = artworkDto.Material,
                Preco = artworkDto.Preco,
                Imagem = artworkDto.Imagem,
                Descricao = artworkDto.Descricao,
                Status = artworkDto.Status,
                Localizacao = artworkDto.Localizacao,
                Proprietario = artworkDto.Proprietario,
                Exposicao = artworkDto.Exposicao,
                ArtistaId = artworkDto.ArtistaId
            };

            await _artworkRepository.AddAsync(artwork);
            await _artworkRepository.SaveChangesAsync(); // Adicionando persistência

            return new ArtworkDTO
            {
                Id = artwork.Id,
                Titulo = artwork.Titulo,
                AnoCriacao = artwork.AnoCriacao,
                Tecnica = artwork.Tecnica,
                Largura = artwork.Largura,
                Altura = artwork.Altura,
                Material = artwork.Material,
                Preco = artwork.Preco,
                Imagem = artwork.Imagem,
                Descricao = artwork.Descricao,
                Status = artwork.Status ?? true,
                Localizacao = artwork.Localizacao,
                Proprietario = artwork.Proprietario,
                Exposicao = artwork.Exposicao,
                ArtistaId = artwork.ArtistaId
            };
        }

        public async Task UpdateAsync(int id, ArtworkDTO artworkDto)
        {
            var artwork = await _artworkRepository.GetByIdAsync(id);
            if (artwork == null) return;

            artwork.Titulo = artworkDto.Titulo;
            artwork.AnoCriacao = artworkDto.AnoCriacao;
            artwork.Tecnica = artworkDto.Tecnica;
            artwork.Largura = artworkDto.Largura;
            artwork.Altura = artworkDto.Altura;
            artwork.Material = artworkDto.Material;
            artwork.Preco = artworkDto.Preco;
            artwork.Imagem = artworkDto.Imagem;
            artwork.Descricao = artworkDto.Descricao;
            artwork.Status = artworkDto.Status;
            artwork.Localizacao = artworkDto.Localizacao;
            artwork.Proprietario = artworkDto.Proprietario;
            artwork.Exposicao = artworkDto.Exposicao;
            artwork.ArtistaId = artworkDto.ArtistaId;

            await _artworkRepository.UpdateAsync(artwork);
        }

        public async Task DeleteAsync(int id)
        {
            await _artworkRepository.DeleteAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _artworkRepository.SaveChangesAsync();
        }

    }
}
