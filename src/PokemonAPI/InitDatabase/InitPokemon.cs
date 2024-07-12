using Entities;
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

        public static IEnumerable<PokemonEntity> GetPokemonArray()
        {
            var list = new List<PokemonEntity>();
            CSVParser _pkmnParser = new CSVParser($"{Directory.GetCurrentDirectory()}/data/pokemon.csv");
            CSVParser _statParser = new CSVParser($"{Directory.GetCurrentDirectory()}/data/pokemon_stats.csv");
            int special;
            for (int i = 1; i < _pkmnParser.GetNumberOfLines(); ++i)
            {
                if (i <= 150)
                {
                    special = _specialArray[i];
                }
                else
                {
                    special = 0;
                }
                int bstIndex = _statParser.GetFirstIndexWhere("pokemon_id", _pkmnParser.GetDataFromColumn("id", i));
                list.Add(new PokemonEntity(
                    int.Parse(_pkmnParser.GetDataFromColumn("id", i)),
                    _pkmnParser.GetDataFromColumn("identifier", i),
                    int.Parse(_statParser.GetDataFromColumn("base_stat", bstIndex)),
                    int.Parse(_statParser.GetDataFromColumn("base_stat", bstIndex + 1)),
                    int.Parse(_statParser.GetDataFromColumn("base_stat", bstIndex + 2)),
                    int.Parse(_statParser.GetDataFromColumn("base_stat", bstIndex + 3)),
                    int.Parse(_statParser.GetDataFromColumn("base_stat", bstIndex + 4)),
                    special,
                    int.Parse(_statParser.GetDataFromColumn("base_stat", bstIndex + 5))
                ));
            }
            return list;
        }
    }
}
