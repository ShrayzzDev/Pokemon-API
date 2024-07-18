using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTest
{
    public class PokemonMoveTest
    {
        public static IEnumerable<object[]> CtorTestData()
        {
            yield return new object[] { 1, new Move(1, "name", new Model.Type("name", "typing"), 1, 1, 1), 1 };
            yield return new object[] { 11, new Move(1, "name", new Model.Type("name", "typing"), 1, 1, 1), 1 };
            yield return new object[] { 1, new Move(1, "name", new Model.Type("name", "typing"), 1, 1, 1), 11 };
        }

        [Theory]
        [MemberData(nameof(CtorTestData))]
        public void PokemonMoveCtorTest(int learningId, Move learned, int learningLevel)
        {
            var pm = new PokemonMove(learningId, learned, learningLevel);

            Assert.Equal(learningId, pm.LearningId);
            Assert.Equal(learned.Id, pm.LearnedMove.Id);
            Assert.Equal(learningLevel, pm.LearningLevel);
        }
    }
}
