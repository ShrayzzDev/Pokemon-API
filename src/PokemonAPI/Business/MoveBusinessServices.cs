using Entities;
using EntityExtensions;
using Model;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class MoveBusinessServices : IMoveService<Move>
    {
        private IMoveService<MoveEntity> _repository;

        public MoveBusinessServices(IMoveService<MoveEntity> repository)
        {
            _repository = repository;
        }

        /// <inheritdoc/>
        public async Task<int> GetLevelMoveLearned(int pokemonId, int moveId)
            => await _repository.GetLevelMoveLearned(pokemonId, moveId);

        /// <inheritdoc/>
        public async Task<Move?> GetMoveById(int id)
            => (await _repository.GetMoveById(id))?.ToModel();

        /// <inheritdoc/>
        public async Task<IEnumerable<Move>?> GetMoveByName(string name, int index, int count)
            => (await _repository.GetMoveByName(name, index, count))?.ToModels();

        /// <inheritdoc/>
        public async Task<IEnumerable<Move>> GetMovesByLearnedLevel(int pokemonId, int learningLevel, int generation)
            => (await _repository.GetMovesByLearnedLevel(pokemonId, learningLevel, generation)).ToModels();
    }
}
