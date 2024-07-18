using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DamageParameters
{
    public class Gen1DamageInformationsDTO
    {
        public Gen1EIValuesDTO TargetIvs { get; set; }

        public Gen1EIValuesDTO TargetEvs { get; set; }

        public Gen1EIValuesDTO DamagingIvs { get; set; }

        public Gen1EIValuesDTO DamagingEvs { get; set; }

        public int DamagingId { get; set; }

        public int DamagingLevel { get; set; }

        public int TargetId { get; set; }

        public int TargetLevel { get; set; }

        public int MoveId { get; set; }

        public bool IsCritical { get; set; }
    }
}
