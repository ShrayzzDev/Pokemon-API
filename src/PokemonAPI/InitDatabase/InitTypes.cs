using Entities;
using Parser;

namespace InitDatabase
{
    public static class InitTypes
    {
        public static IEnumerable<TypeEntity> GetTypesArray()
        {
            return new List<TypeEntity>()
            {
                new TypeEntity("Normal", "Phy"),
                new TypeEntity("Fighting", "Phy"),
                new TypeEntity("Flying", "Phy"),
                new TypeEntity("Poison", "Phy"),
                new TypeEntity("Ground", "Phy"),
                new TypeEntity("Rock", "Phy"),
                new TypeEntity("Bug", "Phy"),
                new TypeEntity("Ghost", "Phy"),
                new TypeEntity("Steel", "Phy"),
                new TypeEntity("Fire", "Spe"),
                new TypeEntity("Water", "Spe"),
                new TypeEntity("Grass", "Spe"),
                new TypeEntity("Electric", "Spe"),
                new TypeEntity("Psychic", "Spe"),
                new TypeEntity("Ice", "Spe"),
                new TypeEntity("Dragon", "Spe"),
                new TypeEntity("Dark", "Phy"),
                new TypeEntity("Fairy", "None")
            };
        }
    }
}
