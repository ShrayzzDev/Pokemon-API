using Entities;
using EntityExtensions;

namespace EntityExtensionsTest
{
    public class TypeExtensionTest
    {
        public static IEnumerable<object[]> ToModelTestData()
        {
            yield return new object[] { "name", "typing" };
            yield return new object[] { "other", "typing" };
            yield return new object[] { "name", "another" };
            yield return new object[] { "other", "another" };
        }

        [Theory]
        [MemberData(nameof(ToModelTestData))]
        public void ToModelTest(string name, string typing)
        {
            var entity = new TypeEntity(name, typing);

            var model = entity.ToModel();

            Assert.Equal(name, model.Name);
            Assert.Equal(typing, model.Typing);
        }

        public static IEnumerable<object[]> ToModelsTestData()
        {
            var type = new TypeEntity( "name", "typing" );
            var type2 = new TypeEntity( "other", "typing");
            var type3 = new TypeEntity( "name", "another");
            var type4 = new TypeEntity( "other", "another");
            yield return new object[] { new List<TypeEntity>() { type } };
            yield return new object[] { new List<TypeEntity>() { type ,type2 } };
            yield return new object[] { new List<TypeEntity>() { type2, type } };
            yield return new object[] { new List<TypeEntity>() { type2, type3 } };
            yield return new object[] { new List<TypeEntity>() { type, type2, type3 } };
            yield return new object[] { new List<TypeEntity>() { type, type2, type4 } };
        }

        [Theory]
        [MemberData(nameof(ToModelsTestData))]
        public void ToModelsTest(IEnumerable<TypeEntity> entities)
        {
            var models = entities.ToModels();

            Assert.Equal(entities.Count(), models.Count());
            for (int i = 0; i < entities.Count(); ++i)
            {
                Assert.Equal(entities.ElementAt(i).Name, models.ElementAt(i).Name);
                Assert.Equal(entities.ElementAt(i).Typing, models.ElementAt(i).Typing);
            }
        }
    }
}