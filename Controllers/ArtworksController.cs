using Microsoft.AspNetCore.Mvc;
using Nexox.DTOs;
using Nexox.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nexox.Controllers
{
    [Route("api/obras")]
    [ApiController]
    public class ArtworksController : ControllerBase
    {
        private readonly ArtworkService _artworkService;

        public ArtworksController(ArtworkService artworkService)
        {
            _artworkService = artworkService;
        }

        // [POST] /obras → Cadastrar nova obra
        [HttpPost]
        public async Task<IActionResult> CreateArtwork([FromBody] ArtworkDTO artworkDto)
        {
            if (artworkDto == null)
            {
                return BadRequest("Dados inválidos.");
            }

            var newArtwork = await _artworkService.AddAsync(artworkDto);
            return CreatedAtAction(nameof(GetArtworkById), new { id = newArtwork.Id }, newArtwork);
        }


        // [GET] /obras → Listar todas as obras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtworkDTO>>> GetAllArtworks()
        {
            var artworks = await _artworkService.GetAllAsync();
            return Ok(artworks);
        }

        // [GET] /obras/{id} → Buscar uma obra específica
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtworkDTO>> GetArtworkById(int id)
        {
            var artwork = await _artworkService.GetByIdAsync(id);
            if (artwork == null)
            {
                return NotFound("Obra não encontrada.");
            }
            return Ok(artwork);
        }
    }
}
