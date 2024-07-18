using DTO;
using DTO.Pokemons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOTest
{
    public class PokemonDTOTest
    {
        public static IEnumerable<object[]> CtorTestData()
        {
            var type = new TypeDTO("name", "typing");
            var type1 = new TypeDTO("name", "typing");
            var type2 = new TypeDTO("name", "typing");
            var pm = new PokemonMoveDTO(1, new MoveDTO(1, "name", new TypeDTO("name", "typing"), 1, 1, 1), 1);
            var pm1 = new PokemonMoveDTO(1, new MoveDTO(1, "name", new TypeDTO("name", "typing"), 1, 1, 1), 1);
            var pm2 = new PokemonMoveDTO(1, new MoveDTO(1, "name", new TypeDTO("name", "typing"), 1, 1, 1), 1);
            yield return new object[] { 1, "name", 1, 1, 1, 1, 1, 1, 1, new List<TypeDTO>() { type }, new List<PokemonMoveDTO>() { pm } };
            yield return new object[] { 10, "name", 1, 1, 1, 1, 1, 1, 1, new List<TypeDTO>() { type1 }, new List<PokemonMoveDTO>() { pm1 } };
            yield return new object[] { 1, "other", 1, 1, 1, 1, 1, 1, 1, new List<TypeDTO>() { type2 }, new List<PokemonMoveDTO>() { pm2 } };
            yield return new object[] { 1, "name", 11, 1, 1, 1, 1, 1, 1, new List<TypeDTO>() { type, type1 }, new List<PokemonMoveDTO>() { pm, pm1 } };
            yield return new object[] { 1, "name", 1, 11, 1, 1, 1, 1, 1, new List<TypeDTO>() { type1, type }, new List<PokemonMoveDTO>() { pm1, pm } };
            yield return new object[] { 1, "name", 1, 1, 11, 1, 1, 1, 1, new List<TypeDTO>() { type1, type2 }, new List<PokemonMoveDTO>() { pm1, pm2 } };
            yield return new object[] { 1, "name", 1, 1, 1, 11, 1, 1, 1, new List<TypeDTO>() { type, type1 }, new List<PokemonMoveDTO>() { pm, pm1, pm2 } };
            yield return new object[] { 1, "name", 1, 1, 1, 1, 11, 1, 1, new List<TypeDTO>() { type1, type }, new List<PokemonMoveDTO>() { pm1, pm, pm2 } };
            yield return new object[] { 1, "name", 1, 1, 1, 1, 1, 11, 1, new List<TypeDTO>() { type2, type1 }, new List<PokemonMoveDTO>() { pm2, pm1, pm } };
            yield return new object[] { 1, "name", 1, 1, 1, 1, 1, 1, 11, new List<TypeDTO>() { type, type2 }, new List<PokemonMoveDTO>() { pm, pm2, pm1 } };
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
                                    IEnumerable<TypeDTO> types,
                                    IEnumerable<PokemonMoveDTO> MoveDTOs)
        {
            var pkmn = new PokemonDTO(id, name, hp, attack, defense, spa, spd, special, speed, types, MoveDTOs);

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
            Assert.Equal(MoveDTOs.Count(), pkmn.MovePool.Count());
        }
    }
}
