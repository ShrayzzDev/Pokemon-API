using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Pokemons
{
    public class SimplePokemon
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public SimplePokemon(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
