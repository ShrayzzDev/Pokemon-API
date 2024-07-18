using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Pokemons
{
    public class SimplePokemonDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public SimplePokemonDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
