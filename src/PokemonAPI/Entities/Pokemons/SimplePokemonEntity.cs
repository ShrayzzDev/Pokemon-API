using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityExtensions.Pokemons
{
    [PrimaryKey(nameof(Id))]
    public class SimplePokemonEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public SimplePokemonEntity() { }

        public SimplePokemonEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
