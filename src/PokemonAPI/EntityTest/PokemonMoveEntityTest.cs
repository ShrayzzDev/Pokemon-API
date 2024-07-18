using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTest
{
    public class PokemonMoveEntityTest
    {
        public static IEnumerable<object[]> CtorTestData()
        {
            yield return new object[] { 1, 1, 1 };
            yield return new object[] { 11, 1, 1 };
            yield return new object[] { 1, 11, 1 };
            yield return new object[] { 1, 1, 11 };
        }

        [Theory]
        [MemberData(nameof(CtorTestData))]
        public void PokemonMoveCtorTest(int learningId, int moveId, int learningLevel)
        {
            var pm = new PokemonMoveEntity(learningId, moveId, learningLevel, 1);

            Assert.Equal(learningId, pm.LearningId);
            Assert.Equal(moveId, pm.LearnedMoveId);
            Assert.Equal(learningLevel, pm.LearningLevel);
        }
    }
}
