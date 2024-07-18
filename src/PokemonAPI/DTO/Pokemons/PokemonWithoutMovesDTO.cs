using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Pokemons
{
    public class PokemonWithoutMovesDTO : SimplePokemonDTO
    {

        public int HP { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }

        public int SP_Attack { get; set; }

        public int SP_Defense { get; set; }

        public int Special { get; set; }

        public int Speed { get; set; }

        public IEnumerable<TypeDTO> Types { get; set; }

        public PokemonWithoutMovesDTO(int id,
                          string name,
                          int hP,
                          int attack,
                          int defense,
                          int sP_Attack,
                          int sP_Defense,
                          int special,
                          int speed,
                          IEnumerable<TypeDTO> types)
            : base(id, name)
        {
            HP = hP;
            Attack = attack;
            Defense = defense;
            SP_Attack = sP_Attack;
            SP_Defense = sP_Defense;
            Special = special;
            Speed = speed;
            Types = types;
        }

    }
}
