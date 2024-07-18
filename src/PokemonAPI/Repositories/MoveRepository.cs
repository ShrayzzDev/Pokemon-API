using Context;
using Entities;
using Microsoft.EntityFrameworkCore;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class MoveRepository : IMoveService<MoveEntity>
    {
        private PokemonDBContext _context;

        public MoveRepository(PokemonDBContext context)
        {
            _context = context;
        }

        public async Task<int> GetLevelMoveLearned(int pokemonId, int moveId)
        {
            var lvl = _context.MovePool
                .Where(mp => mp.LearnedMoveId == moveId
                          && mp.LearningId == pokemonId)
                .Select(mp => mp.LearningLevel);
            if (!lvl.Any()) return -1;
            else return lvl.First();
        }

        /// <inheritdoc/>
        public async Task<MoveEntity?> GetMoveById(int id)
        {
            return await _context.Moves
                .Where(move => move.Id.Equals(id))
                .Include(move => move.Type)
                .FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<MoveEntity>?> GetMoveByName(string name, int index, int count)
        {
            return _context.Moves
                .Include(m => m.Type)
                .AsEnumerable()
                .Where(m => m.Name.Contains(name))
                .Skip((index - 1) * count)
                .Take(count)
                .OrderBy(m => m.Name);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<MoveEntity>> GetMovesByLearnedLevel(int pokemonId, int learningLevel, int generation)
        {
            var pkmn = await _context.Pokemons
                .Where(pkmn => pkmn.Id.Equals(pokemonId))
                .Include(pkmn => pkmn.MovePool)
                .ThenInclude(mp => mp.LearnedMove)
                .ThenInclude(m => m.Type)
                .FirstOrDefaultAsync();
            if (pkmn == null)
            {
                return new List<MoveEntity>();
            }
            var mp = pkmn.MovePool
                .Where(mp => mp.LearningLevel <= learningLevel
                          && mp.Generation == generation)
                .Select(mp => mp.LearnedMove);
            return mp;
        }
    }
}
