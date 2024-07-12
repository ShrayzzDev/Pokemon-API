using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PokemonMoveDTO
    {
        public int LearningId { get; set; }

        public MoveDTO LearnedMove { get; set; }

        public int LearningLevel { get; set; }

        public PokemonMoveDTO(int learningId, MoveDTO learnedMove, int learningLevel)
        {
            LearningId = learningId;
            LearnedMove = learnedMove;
            LearningLevel = learningLevel;
        }
    }
}
