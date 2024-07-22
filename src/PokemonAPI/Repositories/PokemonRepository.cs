using Context;
using Entities.Pokemons;
using EntityExtensions.Pokemons;
using Microsoft.EntityFrameworkCore;
using Services;

namespace Repositories
{
    public class PokemonRepository : IPokemonService<PokemonEntity, PokemonWithoutMovesEntity, SimplePokemonEntity>
    {
        private PokemonDBContext Context;

        public PokemonRepository(PokemonDBContext context)
        {
            Context = context;
        }

        /// <inheritdoc/>
        public async Task<PokemonEntity?> GetPokemonById(int id)
        {
            return await Context.Pokemons
                .Include(p => p.MovePool)
                .ThenInclude(mp => mp.LearnedMove)
                .ThenInclude(m => m.Type)
                .Include(p => p.Types)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<SimplePokemonEntity>> GetPokemonByName(string name, int index, int count)
        {
            return await Context.SimplePokemons
                .Where(p => p.Name.Contains(name))
                .Skip(index * count)
                .Take(count).ToListAsync();
        }

        public async Task<PokemonWithoutMovesEntity?> GetPokemonWithoutMovesById(int id)
        {
            return await Context.PokemonsWithoutMoves
                .Include(pkmn => pkmn.Types)
                .FirstOrDefaultAsync(pkmn => pkmn.Id.Equals(id));
        }
    }
}
