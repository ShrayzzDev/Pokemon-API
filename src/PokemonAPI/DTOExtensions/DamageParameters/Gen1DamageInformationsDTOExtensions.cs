using DTO.DamageParameters;
using Model.DamageParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOExtensions.DamageParameters
{
    public static class Gen1DamageInformationsDTOExtensions
    {
        public static Gen1DamageInformations ToModel(this Gen1DamageInformationsDTO dto)
        {
            return new Gen1DamageInformations(
                dto.TargetIvs.ToModel(true),
                dto.TargetEvs.ToModel(false),
                dto.DamagingIvs.ToModel(true),
                dto.DamagingEvs.ToModel(false),
                dto.DamagingId,
                dto.DamagingLevel,
                dto.TargetId,
                dto.TargetLevel,
                dto.MoveId,
                dto.IsCritical
            );
        }
    }
}
