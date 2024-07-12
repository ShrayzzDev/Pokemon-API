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
            var list = new List<MoveEntity>();
            CSVParser _parser = new CSVParser($"{Directory.GetCurrentDirectory()}/data/moves.csv");
            IEnumerable<string> types = InitTypes.GetTypesArray().Select(type => type.Name);
            for (int i = 1; i < _parser.GetNumberOfLines(); ++i)
            {
                if (_parser.GetDataFromColumn("generation_id", i) != "1")
                {
                    continue;
                }
                int id = 0;
                int power = 0;
                int pp = 0;
                int accuracy = 0;
                int.TryParse(_parser.GetDataFromColumn("id", i), out id);
                int.TryParse(_parser.GetDataFromColumn("power", i), out power);
                int.TryParse(_parser.GetDataFromColumn("pp", i), out pp);
                int.TryParse(_parser.GetDataFromColumn("accuracy", i), out accuracy);
                list.Add(new MoveEntity(
                    id,
                    _parser.GetDataFromColumn("identifier", i),
                    types.ElementAt(int.Parse(_parser.GetDataFromColumn("type_id", i)) - 1),
                    power,
                    pp,
                    accuracy
                ));
            }
            return list;
        }
    }
}
