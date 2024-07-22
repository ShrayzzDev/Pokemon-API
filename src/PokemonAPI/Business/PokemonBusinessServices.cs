using Entities.Pokemons;
using EntityExtensions;
using EntityExtensions.Pokemons;
using Model.Pokemons;
using Services;

namespace Business
{
    public class PokemonBusinessServices : IPokemonService<Pokemon, PokemonWithoutMoves, SimplePokemon>
    {
        private readonly IPokemonService<PokemonEntity, PokemonWithoutMovesEntity, SimplePokemonEntity> _repository;

        public PokemonBusinessServices(IPokemonService<PokemonEntity, PokemonWithoutMovesEntity, SimplePokemonEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Pokemon?> GetPokemonById(int id)
            => (await _repository.GetPokemonById(id))?.ToModel();

        public async Task<IEnumerable<SimplePokemon>> GetPokemonByName(string name, int index, int count)
            => (await _repository.GetPokemonByName(name, index, count)).ToModels();

        public async Task<PokemonWithoutMoves?> GetPokemonWithoutMovesById(int id)
            => (await _repository.GetPokemonWithoutMovesById(id))?.ToModel();
    }
}
