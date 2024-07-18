using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Entities.Pokemons
{
    public class PokemonEntity : PokemonWithoutMovesEntity
    {
        public List<PokemonMoveEntity> MovePool { get; set; } = new List<PokemonMoveEntity>();

        public PokemonEntity() { }

        public PokemonEntity(int id,
                             string name,
                             int hP,
                             int attack,
                             int defense,
                             int sP_Attack,
                             int sP_Defense,
                             int special,
                             int speed)
            : base(id, name, hP, attack, defense, sP_Attack, sP_Defense, special, speed)
        {
        }
    }
}
