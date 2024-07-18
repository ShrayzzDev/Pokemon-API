using Entities.Pokemons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [PrimaryKey(nameof(Name))]
    public class TypeEntity
    {
        [Key]
        public string Name { get; set; } = null!;

        public string Typing { get; set; } = null!;

        public ICollection<PokemonWithoutMovesEntity> Pokemons { get; set; } = new List<PokemonWithoutMovesEntity>();

        public TypeEntity() { }

        public TypeEntity(string name, string typing)
        {
            Name = name;
            Typing = typing;
        }
    }
}
