using Model;
using Model.Pokemons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTest
{
    public class PokemonTest
    {
        public static IEnumerable<object[]> CtorTestData()
        {
            var type = new Model.Type("name", "typing");
            var type1 = new Model.Type("name", "typing");
            var type2 = new Model.Type("name", "typing");
            var pm = new PokemonMove(1, new Move(1, "name", new Model.Type("name", "typing"), 1, 1, 1), 1);
            var pm1 = new PokemonMove(1, new Move(1, "name", new Model.Type("name", "typing"), 1, 1, 1), 1);
            var pm2 = new PokemonMove(1, new Move(1, "name", new Model.Type("name", "typing"), 1, 1, 1), 1);
            yield return new object[] { 1, "name", 1, 1, 1, 1, 1, 1, 1, new List<Model.Type>() { type }, new List<PokemonMove>() { pm } };
            yield return new object[] { 10, "name", 1, 1, 1, 1, 1, 1, 1, new List<Model.Type>() { type1 }, new List<PokemonMove>() { pm1 } };
            yield return new object[] { 1, "other", 1, 1, 1, 1, 1, 1, 1, new List<Model.Type>() { type2 }, new List<PokemonMove>() { pm2 } };
            yield return new object[] { 1, "name", 11, 1, 1, 1, 1, 1, 1, new List<Model.Type>() { type, type1 }, new List<PokemonMove>() { pm, pm1 } };
            yield return new object[] { 1, "name", 1, 11, 1, 1, 1, 1, 1, new List<Model.Type>() { type1, type }, new List<PokemonMove>() { pm1, pm } };
            yield return new object[] { 1, "name", 1, 1, 11, 1, 1, 1, 1, new List<Model.Type>() { type1, type2 }, new List<PokemonMove>() { pm1, pm2 } };
            yield return new object[] { 1, "name", 1, 1, 1, 11, 1, 1, 1, new List<Model.Type>() { type, type1 }, new List<PokemonMove>() { pm, pm1, pm2 } };
            yield return new object[] { 1, "name", 1, 1, 1, 1, 11, 1, 1, new List<Model.Type>() { type1, type }, new List<PokemonMove>() { pm1, pm, pm2 } };
            yield return new object[] { 1, "name", 1, 1, 1, 1, 1, 11, 1, new List<Model.Type>() { type2, type1 }, new List<PokemonMove>() { pm2, pm1, pm } };
            yield return new object[] { 1, "name", 1, 1, 1, 1, 1, 1, 11, new List<Model.Type>() { type, type2 }, new List<PokemonMove>() { pm, pm2, pm1 } };
        }

        [Theory]
        [MemberData(nameof(CtorTestData))]
        public void PokemonCtorTest(int id, 
                                    string name,
                                    int hp,
                                    int attack,
                                    int defense,
                                    int spa,
                                    int spd,
                                    int special,
                                    int speed,
                                    IEnumerable<Model.Type> types,
                                    IEnumerable<PokemonMove> moves)
        {
            var pkmn = new Pokemon(id, name, hp, attack, defense, spa, spd, special, speed, types, moves);

            Assert.Equal(id, pkmn.Id);
            Assert.Equal(name, pkmn.Name);
            Assert.Equal(hp, pkmn.HP);
            Assert.Equal(attack, pkmn.Attack);
            Assert.Equal(defense, pkmn.Defense);
            Assert.Equal(spa, pkmn.SP_Attack);
            Assert.Equal(spd, pkmn.SP_Defense);
            Assert.Equal(special, pkmn.Special);
            Assert.Equal(speed, pkmn.Speed);
            Assert.Equal(types.Count(), pkmn.Types.Count());
            Assert.Equal(moves.Count(), pkmn.MovePool.Count());
        }

        [Fact]
        public void CtorThrowsWhenMoreThan2Types()
        {
            var type = new Model.Type("name", "typing");
            Assert.Throws<ArgumentException>(() =>
                { new Pokemon(1, "name", 1, 1, 1, 1, 1, 1, 1, new List<Model.Type>() { type, type, type }, new List<PokemonMove>()); }
            );
        }
    }
}
