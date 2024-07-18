using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DamageParameters
{
    public class EIValuesDTO
    {
        public int HP { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }

        public int SP_Attack { get; set; }

        public int SP_Defense { get; set; }

        public int Speed { get; set; }

        public EIValuesDTO(int hP, int attack, int defense, int sP_Attack, int sP_Defense, int speed)
        {
            HP = hP;
            Attack = attack;
            Defense = defense;
            SP_Attack = sP_Attack;
            SP_Defense = sP_Defense;
            Speed = speed;
        }
    }
}
