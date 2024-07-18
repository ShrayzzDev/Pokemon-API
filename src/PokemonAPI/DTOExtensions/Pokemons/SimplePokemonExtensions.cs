using DTO.Pokemons;
using Model.Pokemons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOExtensions.Pokemons
{
    public static class SimplePokemonExtensions
    {
        public static SimplePokemonDTO ToDTO(this SimplePokemon model)
        {
            return new SimplePokemonDTO(
                model.Id,
                model.Name
            );
        }

        public static IEnumerable<SimplePokemonDTO> ToDTOs(this IEnumerable<SimplePokemon> models)
        {
            var list = new List<SimplePokemonDTO>();
            foreach (var model in models)
            {
                list.Add(model.ToDTO());
            }
            return list;
        }
    }
}
