using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOTest
{
    public class PokemonMoveDTOTest
    {
        public static IEnumerable<object[]> CtorTestData()
        {
            yield return new object[] { 1, new MoveDTO(1, "name", new TypeDTO("name", "typing"), 1, 1, 1), 1 };
            yield return new object[] { 11, new MoveDTO(1, "name", new TypeDTO("name", "typing"), 1, 1, 1), 1 };
            yield return new object[] { 1, new MoveDTO(1, "name", new TypeDTO("name", "typing"), 1, 1, 1), 11 };
        }

        [Theory]
        [MemberData(nameof(CtorTestData))]
        public void PokemonMoveDTOCtorTest(int learningId, MoveDTO learned, int learningLevel)
        {
            var pm = new PokemonMoveDTO(learningId, learned, learningLevel);

            Assert.Equal(learningId, pm.LearningId);
            Assert.Equal(learned.Id, pm.LearnedMove.Id);
            Assert.Equal(learningLevel, pm.LearningLevel);
        }
    }
}
