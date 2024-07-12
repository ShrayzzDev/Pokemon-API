using Entities;
using EntityExtensions;
using Model;
using Services;

namespace Business
{
    public class PokemonBusinessServices : IPokemonService<Pokemon>
    {
        private readonly IPokemonService<PokemonEntity> _repository;

        public PokemonBusinessServices(IPokemonService<PokemonEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Pokemon?> GetPokemonById(int id)
            => (await _repository.GetPokemonById(id))?.ToModel();

        public async Task<IEnumerable<Pokemon>> GetPokemonByName(string name, int index, int count)
            => (await _repository.GetPokemonByName(name, index, count)).ToModels();
    }
}
