using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    [PrimaryKey(nameof(Id))]
    public class PokemonEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int HP { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }

        public int SP_Attack { get; set; }

        public int SP_Defense { get; set; }

        public int Special { get; set; }

        public int Speed { get; set; }

        public List<TypeEntity> Types { get; set; } = new List<TypeEntity>();

        public List<PokemonMoveEntity> MovePool { get; set; } = new List<PokemonMoveEntity>();

        public PokemonEntity() { }

        public PokemonEntity(int id, string name, int hP, int attack, int defense, int sP_Attack, int sP_Defense, int special, int speed)
        {
            Id = id;
            Name = name;
            HP = hP;
            Attack = attack;
            Defense = defense;
            SP_Attack = sP_Attack;
            SP_Defense = sP_Defense;
            Special = special;
            Speed = speed;
        }
    }
}
