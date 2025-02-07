using Microsoft.AspNetCore.Mvc;
using Nexox.DTOs;
using Nexox.Services;
//using System.Threading.Tasks;

namespace nexox.Controllers
{
    public class ObrasController : Controller
    {
        private readonly IArtworkService _artworkService;

        public ObrasController(IArtworkService artworkService)
        {
            _artworkService = artworkService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CadastroObras()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ArtworkDTO artworkDto)
        {
            if (!ModelState.IsValid)
            {
                // Exibir erros no console para debugging
                foreach (var modelStateKey in ModelState.Keys)
                {
                    var value = ModelState[modelStateKey];
                    foreach (var error in value.Errors)
                    {
                        Console.WriteLine($"Erro na chave {modelStateKey}: {error.ErrorMessage}");
                    }
                }

                // Retorna a mesma página com os erros exibidos
                return View("CadastroObras", artworkDto);
            }

            await _artworkService.AddAsync(artworkDto);
            return RedirectToAction("Index");
        }

    }
}
