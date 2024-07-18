using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DamageParameters
{
    public class Gen1DamageInformations
    {
        public Gen1EIValues TargetIvs;

        public Gen1EIValues TargetEvs;

        public Gen1EIValues DamagingIvs;

        public Gen1EIValues DamagingEvs;

        public int DamagingId;

        public int DamagingLevel;

        public int TargetId;

        public int TagetLevel;

        public int MoveId;

        public bool IsCritical;

        public Gen1DamageInformations(Gen1EIValues targetIvs,
                                      Gen1EIValues targetEvs,
                                      Gen1EIValues damagingtIvs,
                                      Gen1EIValues damagingtEvs,
                                      int damagingId,
                                      int damagingLevel,
                                      int targetId,
                                      int tagetLevel,
                                      int moveId,
                                      bool isCritical)
        {
            TargetIvs = targetIvs;
            TargetEvs = targetEvs;
            DamagingIvs = damagingtIvs;
            DamagingEvs = damagingtEvs;
            DamagingId = damagingId;
            DamagingLevel = damagingLevel;
            TargetId = targetId;
            TagetLevel = tagetLevel;
            MoveId = moveId;
            IsCritical = isCritical;
        }
    }
}
