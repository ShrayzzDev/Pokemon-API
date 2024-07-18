using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DamageParameters
{
    /// <summary>
    /// Represents EV and IVs in Gen1
    /// </summary>
    public class Gen1EIValuesDTO : EIValuesDTO
    {

        public int Special { get; set; }

        public Gen1EIValuesDTO(int hP,
                               int attack,
                               int defense,
                               int sP_Attack,
                               int sP_Defense,
                               int special,
                               int speed)
            : base(hP, attack, defense, sP_Attack, sP_Defense, speed)
        {
            Special = special;
        }
    }
}
