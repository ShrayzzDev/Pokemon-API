using Entities.Pokemons;
using Model.Pokemons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityExtensions.Pokemons
{
    public static class PokemonExtensions
    {
        public static Pokemon ToModel(this PokemonEntity entity)
        {
            return new Pokemon(
                entity.Id,
                entity.Name,
                entity.HP,
                entity.Attack,
                entity.Defense,
                entity.SP_Attack,
                entity.SP_Defense,
                entity.Special,
                entity.Speed,
                entity.Types.ToModels(),
                entity.MovePool.ToModels()
            );
        }

        public static IEnumerable<Pokemon> ToModels(this IEnumerable<PokemonEntity> entities)
        {
            var list = new List<Pokemon>(entities.Count());
            foreach (var entity in entities)
            {
                list.Add(entity.ToModel());
            }
            return list;
        }
    }
}
