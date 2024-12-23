﻿using Entities.Pokemons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [PrimaryKey(nameof(LearningId), nameof(LearnedMoveId), nameof(Generation))]
    public class PokemonMoveEntity
    {
        public int LearningId { get; set; }

        public PokemonEntity Learning { get; set; } = null!;

        public int LearnedMoveId;

        public MoveEntity LearnedMove { get; set; } = null!;

        public int LearningLevel { get; set; }

        public int Generation { get; set; }

        public PokemonMoveEntity() { }

        public PokemonMoveEntity(int learningId, int moveId, int learningLevel, int gen)
        {
            LearningId = learningId;
            LearnedMoveId = moveId;
            LearningLevel = learningLevel;
            Generation = gen;
        }
    }
}
