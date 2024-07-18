using DTO.Pokemons;
using Model.Pokemons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOExtensions.Pokemons
{
    public static class PokemonWithoutMovesDTOExtensions
    {
        public static PokemonWithoutMovesDTO ToDTO(this PokemonWithoutMoves model)
        {
            return new PokemonWithoutMovesDTO(
                model.Id,
                model.Name,
                model.HP,
                model.Attack,
                model.Defense,
                model.SP_Attack,
                model.SP_Defense,
                model.Special,
                model.Speed,
                model.Types.ToDTOs()
            );
        }

        public static IEnumerable<PokemonWithoutMovesDTO> ToDTOs(this IEnumerable<PokemonWithoutMoves> models)
        {
            var list = new List<PokemonWithoutMovesDTO>();
            foreach (var model in models)
            {
                list.Add(model.ToDTO());
            }
            return list;
        }
    }
}
