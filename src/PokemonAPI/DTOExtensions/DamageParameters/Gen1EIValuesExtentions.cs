using DTO.DamageParameters;
using Model.DamageParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOExtensions.DamageParameters
{
    internal static class Gen1EIValuesExtentions
    {
        public static Gen1EIValues ToModel(this Gen1EIValuesDTO dto, bool isIvs)
        {
            return new Gen1EIValues(
                dto.HP,
                dto.Attack,
                dto.Defense,
                dto.Special,
                dto.Speed,
                isIvs
            );
        }
    }
}
