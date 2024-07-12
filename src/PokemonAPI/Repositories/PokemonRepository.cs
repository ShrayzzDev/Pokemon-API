using Context;
using Entities;
using Microsoft.EntityFrameworkCore;
using Services;

namespace Repositories
{
    public class PokemonRepository : IPokemonService<PokemonEntity>
    {
        private PokemonDBContext Context;

        public PokemonRepository(PokemonDBContext context)
        {
            Context = context;
        }

        public async Task<PokemonEntity?> GetPokemonById(int id)
        {
            return await Context.Pokemons
                .Where(p => p.Id == id)
                .Include(p => p.MovePool)
                .ThenInclude(mp => mp.LearnedMove)
                .ThenInclude(m => m.Type)
                .Include(p => p.Types)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PokemonEntity>> GetPokemonByName(string name, int index, int count)
        {
            return await Context.Pokemons
                .Where(p => p.Name.Contains(name))
                .Include(p => p.MovePool)
                .ThenInclude(m => m.LearnedMove.Type)
                .Include(p => p.Types)
                .Skip(index * count)
                .Take(count).ToListAsync();
        }
    }
}
