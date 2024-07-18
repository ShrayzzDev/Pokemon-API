using Context;
using Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitDatabase
{
    public static class InitTypeEfficiency
    {
        public static IEnumerable<TypeEfficiencyEntity> GetTypeEfficiencyArray()
        {
            var parser = new CSVParser($"{Directory.GetCurrentDirectory()}/data/type_efficacy.csv");
            var list = new List<TypeEfficiencyEntity>(parser.GetNumberOfLines());
            var typeDict = InitTypes.GetTypesDict();
            for (int i = 1; i < parser.GetNumberOfLines(); ++i)
            {
                list.Add(new TypeEfficiencyEntity(
                    typeDict[int.Parse(parser.GetDataFromColumn("damage_type_id", i)) - 1].Name,
                    typeDict[int.Parse(parser.GetDataFromColumn("target_type_id", i)) - 1].Name,
                    int.Parse(parser.GetDataFromColumn("damage_factor", i))
                ));
            }
            return list;
        }
    }
}
