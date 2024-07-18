using Entities;
using EntityExtensions;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EntityExtensionsTest
{
    public static class PokemonMoveExtensionsTest
    {
        public static IEnumerable<object[]> ToModelTestData()
        {
            var move = new MoveEntity(1, "name", "type", 1, 1, 1);
            move.Type = new TypeEntity("type", "typing");
            yield return new object[] { 1, move, 1 };
            yield return new object[] { 2, move, 1 };
            yield return new object[] { 1, move, 2 };
        }

        public static void ToModelTest(int learningId, MoveEntity learnedMove, int learningLevel)
        {
            var entity = new PokemonMoveEntity(learningId, learnedMove.Id, learningLevel, 1);
            entity.LearnedMove = learnedMove;

            var model = entity.ToModel();

            Assert.Equal(learningId, model.LearningId);
            Assert.Equal(learnedMove.Id, model.LearnedMove.Id);
            Assert.Equal(learningId, model.LearningId);
        }

        public static IEnumerable<object[]> ToModelsTestData()
        {
            var move = new MoveEntity(1, "name", "type", 1, 1, 1);
            move.Type = new TypeEntity("type", "typing");
            var pm = new PokemonMoveEntity(1, 1, 1, 1);
            pm.LearnedMove = move;
            var pm1 = new PokemonMoveEntity(1, 2 ,1, 1);
            pm1.LearnedMove = move;
            var pm2 = new PokemonMoveEntity(1, 1 ,3, 1);
            pm2.LearnedMove = move;
            yield return new object[] { new List<PokemonMoveEntity>() { pm } };
            yield return new object[] { new List<PokemonMoveEntity>() { pm1 } };
            yield return new object[] { new List<PokemonMoveEntity>() { pm2 } };
            yield return new object[] { new List<PokemonMoveEntity>() { pm, pm1 } };
            yield return new object[] { new List<PokemonMoveEntity>() { pm1, pm } };
            yield return new object[] { new List<PokemonMoveEntity>() { pm1, pm2 } };
            yield return new object[] { new List<PokemonMoveEntity>() { pm, pm2 } };
            yield return new object[] { new List<PokemonMoveEntity>() { pm, pm1, pm2 } };
            yield return new object[] { new List<PokemonMoveEntity>() { pm2, pm, pm1 } };
            yield return new object[] { new List<PokemonMoveEntity>() { pm1, pm2, pm } };
        }

        public static void ToModelsTestData(IEnumerable<PokemonMoveEntity> entities)
        {
            var models = entities.ToModels();

            Assert.Equal(entities.Count(), models.Count());
            for (int i = 0; i < entities.Count(); ++i)
            {
                var entity = entities.ElementAt(i);
                var model = models.ElementAt(i);

                Assert.Equal(entity.LearningId, model.LearningId);
                Assert.Equal(entity.LearnedMoveId, model.LearnedMove.Id);
                Assert.Equal(entity.LearningLevel, model.LearningLevel);
            }
        }
    }
}
