using DTO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOExtensions
{
    public static class PokemoveMoveExtensions
    {
        public static PokemonMoveDTO ToDTO(this PokemonMove move)
        {
            return new PokemonMoveDTO(
                move.LearningId,
                move.LearnedMove.ToDTO(),
                move.LearningLevel
            );
        }

        public static IEnumerable<PokemonMoveDTO> ToDTOs(this IEnumerable<PokemonMove> models)
        {
            var list = new List<PokemonMoveDTO>();
            foreach(var model in models)
            {
                list.Add(model.ToDTO());
            }
            return list;
        }
    }
}
