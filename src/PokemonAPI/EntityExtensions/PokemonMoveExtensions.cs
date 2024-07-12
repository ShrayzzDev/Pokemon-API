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
            Console.WriteLine(entity.LearnedMove.Id);
            return new PokemonMove(
                entity.Learning.Id,
                entity.LearnedMove.ToModel(),
                entity.LearningLevel
            );
        }

        public static IEnumerable<PokemonMove> ToModel(this IEnumerable<PokemonMoveEntity> models)
        {
            var list = new List<PokemonMove>();
            foreach (var model in models)
            {
                list.Add(model.ToModel());
            }
            return list;
        }
    }
}
