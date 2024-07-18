using Context;
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
        /// <summary>
        /// Gives a dictionnary giving each generation_id
        /// its generation number
        /// </summary>
        /// <returns>The dict.</returns>
        private static Dictionary<int, int> GetGenerationDictionnary()
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            CSVParser parser = new CSVParser($"{Directory.GetCurrentDirectory()}/data/version_groups.csv");
            for (int i = 1; i < parser.GetNumberOfLines(); ++i)
            {
                dict.Add(
                    int.Parse(parser.GetDataFromColumn("id", i)),
                    int.Parse(parser.GetDataFromColumn("generation_id", i))
                );
            }
            return dict;
        }

        public async static Task<IEnumerable<PokemonMoveEntity>> GetPokemonMoveArray(PokemonDBContext context)
        {
            CSVParser parser = new CSVParser($"{Directory.GetCurrentDirectory()}/data/pokemon_moves.csv");
            var verDict = GetGenerationDictionnary();
            var list = new List<PokemonMoveEntity>(parser.GetNumberOfLines());
            var movArr = InitMoves.GetMovesArray();
            var pokArr = await InitPokemon.GetPokemonArray(context);
            int pokId;
            int movId;
            for (int i = 1; i < parser.GetNumberOfLines(); ++i)
            {
                pokId = int.Parse(parser.GetDataFromColumn("pokemon_id", i));
                movId = int.Parse(parser.GetDataFromColumn("move_id", i));
                if (!list.Exists(pm => 
                    pm.LearningId == pokId
                 && pm.LearnedMoveId == movId
                ))
                {
                    list.Add(new PokemonMoveEntity(
                        pokId,
                        movId,
                        int.Parse(parser.GetDataFromColumn("level", i)),
                        verDict[int.Parse(parser.GetDataFromColumn("version_group_id",i))]
                    ));
                }
            }
            return list;
        }
    }
}
