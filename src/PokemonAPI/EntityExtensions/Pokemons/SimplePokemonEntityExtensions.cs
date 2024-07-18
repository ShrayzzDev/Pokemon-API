using Model.Pokemons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityExtensions.Pokemons
{
    public static class SimplePokemonEntityExtensions
    {
        public static SimplePokemon ToModel(this SimplePokemonEntity entity)
        {
            return new SimplePokemon(
                entity.Id,
                entity.Name
            );
        }

        public static IEnumerable<SimplePokemon> ToModels(this IEnumerable<SimplePokemonEntity> entities)
        {
            var list = new List<SimplePokemon>();
            foreach (var entity in entities)
            {
                list.Add(entity.ToModel());
            }
            return list;
        }
    }
}
