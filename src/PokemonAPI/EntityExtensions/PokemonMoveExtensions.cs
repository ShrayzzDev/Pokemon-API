using Entities;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityExtensions
{
    public static class PokemonMoveExtensions
    {
        public static PokemonMove ToModel(this PokemonMoveEntity entity)
        {
            return new PokemonMove(
                entity.Learning.Id,
                entity.LearnedMove.ToModel(),
                entity.LearningLevel
            );
        }

        public static IEnumerable<PokemonMove> ToModels(this IEnumerable<PokemonMoveEntity> entities)
        {
            var list = new List<PokemonMove>(entities.Count());
            foreach (var model in entities)
            {
                list.Add(model.ToModel());
            }
            return list;
        }
    }
}
