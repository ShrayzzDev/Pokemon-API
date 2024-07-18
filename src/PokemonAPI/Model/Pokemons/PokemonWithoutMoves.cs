using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Pokemons
{
    public class PokemonWithoutMoves : SimplePokemon
    {

        public int HP { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }

        public int SP_Attack { get; set; }

        public int SP_Defense { get; set; }

        public int Special { get; set; }

        public int Speed { get; set; }

        public IEnumerable<Type> Types { get; set; }

        public PokemonWithoutMoves(int id,
                       string name,
                       int hP,
                       int attack,
                       int defense,
                       int sP_Attack,
                       int sP_Defense,
                       int special,
                       int speed,
                       IEnumerable<Type> types)
            : base(id, name)
        {

            HP = hP;
            Attack = attack;
            Defense = defense;
            SP_Attack = sP_Attack;
            SP_Defense = sP_Defense;
            Special = special;
            Speed = speed;
            if (types.Count() > 2)
            {
                throw new ArgumentException($"Pokemon can't have more than 2 types. (name: {name})");
            }
            Types = types;
        }
    }
}
