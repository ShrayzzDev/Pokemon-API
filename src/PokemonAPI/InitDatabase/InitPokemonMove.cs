using Entities;
using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitDatabase
{
    public static class InitPokemonMove
    {
        public static IEnumerable<PokemonMoveEntity> GetPokemonMoveArray()
        {
            var list = new List<PokemonMoveEntity>();
            CSVParser _parser = new CSVParser($"{Directory.GetCurrentDirectory()}/data/pokemon_moves.csv");
            for (int i = 1; i < _parser.GetNumberOfLines(); ++i)
            {
                if (int.Parse(_parser.GetDataFromColumn("pokemon_id", i)) > 151)
                {
                    break;
                }
                if (int.Parse(_parser.GetDataFromColumn("version_group_id", i)) > 2)
                {
                    continue;
                }
                if (!list.Exists(pm => 
                    pm.LearningId == int.Parse(_parser.GetDataFromColumn("pokemon_id", i))
                 && pm.LearnedMoveId == int.Parse(_parser.GetDataFromColumn("move_id", i))
                ))
                {
                    list.Add(new PokemonMoveEntity(
                        int.Parse(_parser.GetDataFromColumn("pokemon_id", i)),
                        int.Parse(_parser.GetDataFromColumn("move_id", i)),
                        int.Parse(_parser.GetDataFromColumn("level", i))
                    ));
                }
            }
            return list;
        }
    }
}
