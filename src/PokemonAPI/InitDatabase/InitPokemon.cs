using Context;
using Entities.Pokemons;
using Microsoft.EntityFrameworkCore;
using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitDatabase
{
    public static class InitPokemon
    {
        /// <summary>
        /// Array containing all the "Special" stat
        /// values. Only used for Gen 1 (only generation where
        /// the stat exists)
        /// </summary>
        private readonly static int[] _specialArray =
                [65,80,100,50,65,85,50,65,85,20,
                25,80,20,25,45,35,50,70,25,50,
                31,61,40,65,50,90,30,55,40,55,
                75,40,55,75,60,85,65,100,25,50,
                40,75,75,85,100,55,80,40,90,45,
                70,40,65,50,80,35,60,50,80,40,
                50,70,105,120,135,35,50,65,70,85,
                100,100,120,30,45,55,65,80,40,80,
                95,120,58,35,60,70,95,40,65,45,
                85,100,115,130,30,90,115,25,50,55,
                80,60,125,40,50,35,35,60,60,85,
                30,45,105,100,40,70,98,50,80,70,
                100,100,55,95,85,85,55,70,20,100,
                95,48,65,110,110,110,75,90,115,45,
                70,60,65,125,125,125,80,70,100,154,100];

        public async static Task<IEnumerable<PokemonEntity>> GetPokemonArray(PokemonDBContext context)
        {
            var pkmnParser = new CSVParser($"{Directory.GetCurrentDirectory()}/data/pokemon.csv");
            var typeParser = new CSVParser($"{Directory.GetCurrentDirectory()}/data/pokemon_types.csv");
            var statParser = new CSVParser($"{Directory.GetCurrentDirectory()}/data/pokemon_stats.csv");
            var list = new List<PokemonEntity>(pkmnParser.GetNumberOfLines());
            var typeDict = InitTypes.GetTypesDict();
            int special;
            string pokId;
            int i;
            int j = 1;
            for (i = 1; i < pkmnParser.GetNumberOfLines(); ++i)
            {
                pokId = pkmnParser.GetDataFromColumn("id", i);
                special = i <= 150 ? _specialArray[i] : 0;
                int bstIndex = statParser.GetFirstIndexWhere("pokemon_id", pokId);
                var pkmn = new PokemonEntity(
                    int.Parse(pokId),
                    pkmnParser.GetDataFromColumn("identifier", i),
                    int.Parse(statParser.GetDataFromColumn("base_stat", bstIndex)),
                    int.Parse(statParser.GetDataFromColumn("base_stat", bstIndex + 1)),
                    int.Parse(statParser.GetDataFromColumn("base_stat", bstIndex + 2)),
                    int.Parse(statParser.GetDataFromColumn("base_stat", bstIndex + 3)),
                    int.Parse(statParser.GetDataFromColumn("base_stat", bstIndex + 4)),
                    special,
                    int.Parse(statParser.GetDataFromColumn("base_stat", bstIndex + 5))
                );
                string typeName;
                while (typeParser.GetDataFromColumn("pokemon_id",j) == pokId)
                {
                    typeName = typeDict[int.Parse(typeParser.GetDataFromColumn("type_id", j)) - 1].Name;
                    pkmn.Types.Add(
                        context.Types.Where(t => t.Name.Equals(typeName)).First()
                    );
                    ++j;
                }
                list.Add(pkmn);
            }
            return list;
        }
    }
}
