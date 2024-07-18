using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IMoveService<T> where T: class
    {
        /// <summary>
        /// Gets a move using its Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>The move, null if not found</returns>
        public Task<T?> GetMoveById(int id);

        /// <summary>
        /// Returns the list of moves a pokemon learning
        /// at passed level.
        /// </summary>
        /// <param name="pokemonId">Id of the pokemon</param>
        /// <param name="learningLevel">Level</param>
        /// <param name="generation">Get the generation to check.</param>
        /// <returns>Enumerable of moves, empty if nothing found.</returns>
        public Task<IEnumerable<T>> GetMovesByLearnedLevel(int pokemonId, int learningLevel, int generation);

        /// <summary>
        /// Returns the level a Pokemon learns a move
        /// </summary>
        /// <param name="pokemonId">Id of the pokemon</param>
        /// <param name="moveId">Id of the move</param>
        /// <returns>The level learned, -1 if not learned</returns>
        public Task<int> GetLevelMoveLearned(int pokemonId, int moveId);

        /// <summary>
        /// Retrieves a move by its name
        /// </summary>
        /// <param name="name">Name of the move</param>
        /// <returns>The move, null if not found</returns>
        public Task<IEnumerable<T>?> GetMoveByName(string name, int index, int count);
    }
}
