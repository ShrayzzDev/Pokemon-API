using System.ComponentModel.DataAnnotations;

namespace Model.Pokemons
{
    public class Pokemon : PokemonWithoutMoves
    {

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
            : base(id, name, hP, attack, defense, sP_Attack, sP_Defense, special, speed, types)
        {
            MovePool = movePool;
        }
    }
}
