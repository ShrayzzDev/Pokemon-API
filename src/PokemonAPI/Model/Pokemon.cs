using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Pokemon
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int HP { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }

        public int SP_Attack { get; set; }

        public int SP_Defense { get; set; }

        public int Special { get; set; }

        public int Speed { get; set; }

        public IEnumerable<Type> Types { get; set; }

        public IEnumerable<PokemonMove> MovePool { get; set; }

        public Pokemon(int id,
                       string name, 
                       int hP, 
                       int attack,
                       int defense, 
                       int sP_Attack,
                       int sP_Defense,
                       int special, 
                       int speed, 
                       IEnumerable<Type> types,
                       IEnumerable<PokemonMove> movePool)
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
            if (types.Count() > 2)
            {
                throw new ArgumentException($"Pokemon can't have more than 2 types. (name: {name})");
            }
            Types = types;
            MovePool = movePool;
        }
    }
}
