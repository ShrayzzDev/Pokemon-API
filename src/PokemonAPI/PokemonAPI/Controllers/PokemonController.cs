using Context;
using DTO;
using DTOExtensions;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace PokemonAPI.Controllers
{
    [ApiController]
    [Route("pokemon")]
    public class PokemonController : Controller
    {
        private readonly IPokemonService<Pokemon> _pokemonService;

        private readonly ILogger<PokemonController> _logger;

        private PokemonDBContext _context;

        public PokemonController(IPokemonService<Pokemon> pokemonService, ILogger<PokemonController> logger, PokemonDBContext con
            )
        {
            this._pokemonService = pokemonService;
            _logger = logger;
            _context = con;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PokemonDTO), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetPokemonById([FromQuery]int id)
        {
            _logger.LogInformation($"{DateTime.Now} | An user is trying to retrieve the n°{id} pokemon");
            Pokemon? pokemon = null;
            try
            {
                pokemon = await _pokemonService.GetPokemonById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now} | Unexpected exception catched when requesting pokemon n°{id}: {ex.Message}");
                return Problem("An unexpected exception was catched. Please send a ticket on the GitHub repository with the (rough) time this request was made.");
            }

            if (pokemon == null)
            {
                _logger.LogInformation($"{DateTime.Now} | The pokemon n°{id} was not found.");
                return NotFound("The API was unable to find said pokemon.");
            }

            _logger.LogInformation($"{DateTime.Now} | The pokemon was successfully found.");
            return Ok(pokemon.ToDTO());
        }
    }
}
