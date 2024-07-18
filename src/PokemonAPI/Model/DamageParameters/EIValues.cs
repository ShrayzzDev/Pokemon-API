using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DamageParameters
{
    public abstract class EIValues
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public ushort HP { get; set; }

        public ushort Attack { get; set; }

        public ushort Defense { get; set; }

        public ushort SP_Attack { get; set; }

        public ushort SP_Defense { get; set; }

        public ushort Speed { get; set; }

        public EIValues(ushort hP,
                        ushort attack,
                        ushort defense,
                        ushort sP_Attack,
                        ushort sP_Defense, 
                        ushort speed,
                        bool isIVs)
        {
            HP = hP;
            Attack = attack;
            Defense = defense;
            SP_Attack = sP_Attack;
            SP_Defense = sP_Defense;
            Speed = speed;
            if (!CheckValidity(isIVs))
            {
                if (isIVs)
                    throw new ArgumentOutOfRangeException("IVs can not be over 31");
                else
                    throw new ArgumentOutOfRangeException("EVs can not be over 255");
            }
        }

        abstract protected bool CheckValidity(bool isIVs);
    }
}
