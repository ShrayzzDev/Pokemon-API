using Entities;
using EntityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EntityExtensionsTest
{
    public static class MoveExtensionsTest
    {
        public static IEnumerable<object[]> ToModelTestData()
        {
            yield return new object[] { 1, "name", 10, 10, 10 };
            yield return new object[] { 2, "name", 10, 10, 10 };
            yield return new object[] { 1, "other", 10, 10, 10 };
            yield return new object[] { 1, "name", 100, 10, 10 };
            yield return new object[] { 1, "name", 10, 100, 10 };
            yield return new object[] { 1, "name", 10, 10, 100 };
        }

        [Theory]
        [MemberData(nameof(ToModelTestData))]
        public static void ToModelTest(int id, string name, int power, int pP, int accuracy)
        {
            var entity = new MoveEntity(id, name, "type", power, pP, accuracy);
            entity.Type = new TypeEntity("type", "typing");

            var model = entity.ToModel();

            Assert.Equal(id, model?.Id);
            Assert.Equal(name, model?.Name);
            Assert.Equal(power, model?.Power);
            Assert.Equal(pP, model?.PP);
            Assert.Equal(accuracy, model?.Accuracy);
        }

        public static IEnumerable<object[]> ToModelsTestData()
        {
            var move = new MoveEntity(1, "name", "type", 1, 1, 1);
            move.Type = new TypeEntity("type", "typing");
            var move1 = new MoveEntity(1, "other", "type", 1, 1, 1);
            move1.Type = new TypeEntity("type", "typing");
            var move2 = new MoveEntity(1, "name", "type", 10, 1, 1);
            move2.Type = new TypeEntity("type", "typing");
            yield return new object[] { new List<MoveEntity>() { move } };
            yield return new object[] { new List<MoveEntity>() { move1 } };
            yield return new object[] { new List<MoveEntity>() { move2 } };
            yield return new object[] { new List<MoveEntity>() { move, move1 } };
            yield return new object[] { new List<MoveEntity>() { move1, move } };
            yield return new object[] { new List<MoveEntity>() { move, move2 } };
            yield return new object[] { new List<MoveEntity>() { move1, move2 } };
            yield return new object[] { new List<MoveEntity>() { move, move1, move2 } };
            yield return new object[] { new List<MoveEntity>() { move2, move, move1 } };
            yield return new object[] { new List<MoveEntity>() { move1, move2, move } };
        }

        [Theory]
        [MemberData(nameof(ToModelsTestData))]
        public static void ToModelsTest(IEnumerable<MoveEntity> entities)
        {
            var models = entities.ToModels();

            Assert.Equal(entities.Count(), models.Count());
            for (int i = 0; i < entities.Count(); ++i)
            {
                var entity = entities.ElementAt(i);
                var model = models.ElementAt(i);

                Assert.Equal(entity?.Id, model?.Id);
                Assert.Equal(entity?.Name, model?.Name);
                Assert.Equal(entity?.Power, model?.Power);
                Assert.Equal(entity?.PP, model?.PP);
                Assert.Equal(entity?.Accuracy, model?.Accuracy);
            }
        }
    }
}
