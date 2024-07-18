using Entities;
using Parser;

namespace InitDatabase
{
    public static class InitTypes
    {
        public static Dictionary<int, TypeEntity> GetTypesDict()
        {
            var dict = new Dictionary<int, TypeEntity>();
            dict.Add(0, new TypeEntity("Normal", "Phy"));
            dict.Add(1, new TypeEntity("Fighting", "Phy"));
            dict.Add(2, new TypeEntity("Flying", "Phy"));
            dict.Add(3, new TypeEntity("Poison", "Phy"));
            dict.Add(4, new TypeEntity("Ground", "Phy"));
            dict.Add(5, new TypeEntity("Rock", "Phy"));
            dict.Add(6, new TypeEntity("Bug", "Phy"));
            dict.Add(7, new TypeEntity("Ghost", "Phy"));
            dict.Add(8, new TypeEntity("Steel", "Phy"));
            dict.Add(9, new TypeEntity("Fire", "Spe"));
            dict.Add(10, new TypeEntity("Water", "Spe"));
            dict.Add(11, new TypeEntity("Grass", "Spe"));
            dict.Add(12, new TypeEntity("Electric", "Spe"));
            dict.Add(13, new TypeEntity("Psychic", "Spe"));
            dict.Add(14, new TypeEntity("Ice", "Spe"));
            dict.Add(15, new TypeEntity("Dragon", "Spe"));
            dict.Add(16, new TypeEntity("Dark", "Phy"));
            dict.Add(17, new TypeEntity("Fairy", "None"));
            dict.Add(10001, new TypeEntity("Shadow", "None"));
            return dict;
        }
    }
}
