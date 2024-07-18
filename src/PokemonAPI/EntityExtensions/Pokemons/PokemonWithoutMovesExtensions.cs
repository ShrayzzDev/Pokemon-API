using Entities.Pokemons;
using Model.Pokemons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityExtensions.Pokemons
{
    public static class PokemonWithoutMovesExtensions
    {
        public static PokemonWithoutMoves ToModel(this PokemonWithoutMovesEntity entity)
        {
            return new PokemonWithoutMoves(
                entity.Id,
                entity.Name,
                entity.HP,
                entity.Attack,
                entity.Defense,
                entity.SP_Attack,
                entity.SP_Defense,
                entity.Special,
                entity.Speed,
                entity.Types.ToModels()
            );
        }

        public static IEnumerable<PokemonWithoutMoves> ToModels(this IEnumerable<PokemonWithoutMovesEntity> entities)
        {
            var list = new List<PokemonWithoutMoves>(entities.Count());
            foreach (var entity in entities)
            {
                list.Add(entity.ToModel());
            }
            return list;
        }
    }
}
