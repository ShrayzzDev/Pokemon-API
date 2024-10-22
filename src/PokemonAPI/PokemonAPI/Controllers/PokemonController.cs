using Context;
using DTO;
using DTO.Pokemons;
using DTOExtensions;
using DTOExtensions.Pokemons;
using Entities;
using EntityExtensions.Pokemons;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Pokemons;
using Services;

namespace PokemonAPI.Controllers
{
    [ApiController]
    [Route("pokemon")]
    [EnableCors("AllowSpecificOrigins")]
    public class PokemonController : Controller
    {
        private readonly IPokemonService<Pokemon, PokemonWithoutMoves, SimplePokemon> _pokemonService;

        private readonly ILogger<PokemonController> _logger;

        private readonly IMoveService<Move> _moveService;

        public PokemonController(IPokemonService<Pokemon, PokemonWithoutMoves, SimplePokemon> pokemonService,
                                 IMoveService<Move> moveService,
                                 ILogger<PokemonController> logger
            )
        {
            _pokemonService = pokemonService;
            _moveService = moveService;
            _logger = logger;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(PokemonDTO), 200)]
        [ProducesResponseType(404)]
        [EnableCors("AllowSpecificOrigins")]
        public async Task<IActionResult> GetPokemonById(int id)
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
                return Problem("An unexpected exception was catched. \nPlease send a ticket on the GitHub repository with the (rough) time this request was made. \n If you ran this yourself, please include logs.");
            }

            if (pokemon == null)
            {
                _logger.LogInformation($"{DateTime.Now} | The pokemon n°{id} was not found.");
                return NotFound("The API was unable to find said pokemon.");
            }

            _logger.LogInformation($"{DateTime.Now} | The pokemon was successfully found.");
            return Ok(pokemon.ToDTO());
        }

        [HttpGet]
        [Route("{name}/{index}/{count}")]
        [EnableCors("AllowSpecificOrigins")]
        public async Task<IActionResult> GetPokemonByName(string name, int index, int count)
        {
            _logger.LogInformation($"{DateTime.Now} | An user is trying to retrieve the {name} pokemon");
            IEnumerable<SimplePokemon> pokemons;
            try
            {
                pokemons = await _pokemonService.GetPokemonByName(name, index, count);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now} | Unexpected exception catched when requesting pokemon {name}: {ex.Message}");
                return Problem("An unexpected exception was catched. \nPlease send a ticket on the GitHub repository with the (rough) time this request was made. \n If you ran this yourself, please include logs.");
            }

            if (pokemons == null)
            {
                _logger.LogInformation($"{DateTime.Now} | No pokemons containing {name} were found.");
                return NotFound("The API was unable to find said pokemon.");
            }

            _logger.LogInformation($"{DateTime.Now} | Pokemons were successfully found.");
            return Ok(pokemons.ToDTOs());
        }

        [HttpGet]
        [Route("{id}/Moves/{generation}g/{level}")]
        [EnableCors("AllowSpecificOrigins")]
        public async Task<IActionResult> GetMovesForPokemon(int id, ushort level, ushort generation)
        {
            _logger.LogInformation($"{DateTime.Now} | An user is trying to retrive the move pool of pokemon {id} at level {level}");
            if (level > 100)
            {
                _logger.LogInformation($"{DateTime.Now} | Pokemons can't be over level 100");
                return BadRequest("The level indicated is wrong, pokemons can not be over level 100");
            }
            IEnumerable<MoveDTO> moves;
            try
            {
                moves = (await _moveService.GetMovesByLearnedLevel(id, level, generation)).ToDTOs();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now} | Unexpected exception catched when requesting the movepool of pokemon n°{id} at level {level}: {ex.Message}");
                return Problem("An unexpected exception was catched. \nPlease send a ticket on the GitHub repository with the (rough) time this request was made. \n If you ran this yourself, please include logs.");
            }

            if (moves.Count() == 0)
            {
                _logger.LogInformation($"{DateTime.Now} | No move found.");
                return NotFound("The API was unable to find moves from said pokemon.");
            }

            _logger.LogInformation($"{DateTime.Now} | Movepool sucessfully retrieved !");
            return Ok(moves);
        }
    }
}
