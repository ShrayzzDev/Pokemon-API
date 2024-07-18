using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DamageParameters
{
    /// <summary>
    /// NOTE : Here, the EV values is considered
    /// as the equivalent of the STATEXP.
    /// </summary>
    public class Gen1EIValues : EIValues
    {
        public int Special { get; set; }

        public Gen1EIValues(int hP,
                            int attack,
                            int defense,
                            int special,
                            int speed,
                            bool isIVs)
            : base((ushort)hP,
                   (ushort)attack,
                   (ushort)defense,
                   0,
                   0,
                   (ushort)speed,
                   isIVs)
        {
            Special = special;
            if (!CheckValidity(isIVs))
            {
                throw new ArgumentOutOfRangeException("IVs are over 31, or STATEXP over 65535");
            }
        }

        protected override bool CheckValidity(bool IsIVs)
        {
            int val;
            if (IsIVs)
            {
                val = 31;
            }
            else
            {
                val = 65535;
            }
            return HP <= val
                && Attack <= val
                && Defense <= val
                && Special <= val
                && Speed <= val;
        }
    }
}
