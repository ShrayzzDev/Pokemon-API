using Entities;
using Entities.Pokemons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTest
{
    public class PokemonEntityTest
    {
        public static IEnumerable<object[]> CtorTestData()
        {
            yield return new object[] { 1, "name", 1, 1, 1, 1, 1, 1, 1 };
            yield return new object[] { 10, "name", 1, 1, 1, 1, 1, 1, 1 };
            yield return new object[] { 1, "other", 1, 1, 1, 1, 1, 1, 1 };
            yield return new object[] { 1, "name", 11, 1, 1, 1, 1, 1, 1 };
            yield return new object[] { 1, "name", 1, 11, 1, 1, 1, 1, 1 };
            yield return new object[] { 1, "name", 1, 1, 11, 1, 1, 1, 1 };
            yield return new object[] { 1, "name", 1, 1, 1, 11, 1, 1, 1 };
            yield return new object[] { 1, "name", 1, 1, 1, 1, 11, 1, 1 };
            yield return new object[] { 1, "name", 1, 1, 1, 1, 1, 11, 1 };
            yield return new object[] { 1, "name", 1, 1, 1, 1, 1, 1, 11 };
        }

        [Theory]
        [MemberData(nameof(CtorTestData))]
        public void PokemonCtorTest(int id, string name, int hp, int attack, int defense, int spa, int spd, int special, int speed)
        {
            var pkmn = new PokemonEntity(id, name, hp, attack, defense, spa, spd, special, speed);

            Assert.Equal(id, pkmn.Id);
            Assert.Equal(name, pkmn.Name);
            Assert.Equal(hp, pkmn.HP);
            Assert.Equal(attack, pkmn.Attack);
            Assert.Equal(defense, pkmn.Defense);
            Assert.Equal(spa, pkmn.SP_Attack);
            Assert.Equal(spd, pkmn.SP_Defense);
            Assert.Equal(special, pkmn.Special);
            Assert.Equal(speed, pkmn.Speed);
        }
    }
}
