using Entities;
using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitDatabase
{
    public static class InitMoves
    {
        public static IEnumerable<MoveEntity> GetMovesArray()
        {
            CSVParser parser = new CSVParser($"{Directory.GetCurrentDirectory()}/data/moves.csv");
            var list = new List<MoveEntity>(parser.GetNumberOfLines());
            var types = InitTypes.GetTypesDict();
            for (int i = 1; i < parser.GetNumberOfLines(); ++i)
            {
                int.TryParse(parser.GetDataFromColumn("id", i), out int id);
                int.TryParse(parser.GetDataFromColumn("power", i), out int power);
                int.TryParse(parser.GetDataFromColumn("pp", i), out int pp);
                int.TryParse(parser.GetDataFromColumn("accuracy", i), out int accuracy);
                list.Add(new MoveEntity(
                    id,
                    parser.GetDataFromColumn("identifier", i),
                    types[int.Parse(parser.GetDataFromColumn("type_id", i)) - 1].Name,
                    power,
                    pp,
                    accuracy
                ));
            }
            return list;
        }
    }
}
