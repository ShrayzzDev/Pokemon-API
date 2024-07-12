using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PokemonMove
    {
        public int LearningId { get; set; }

        public Move LearnedMove { get; set; }

        public int LearningLevel { get; set; }

        public PokemonMove(int learningId, Move learnedMove, int learningLevel)
        {
            LearningId = learningId;
            LearnedMove = learnedMove;
            LearningLevel = learningLevel;
        }
    }
}
