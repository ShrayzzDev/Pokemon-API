using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [PrimaryKey(nameof(DamagingId), nameof(TargetId))]
    public class TypeEfficiencyEntity
    {
        public string DamagingId { get; set; } = null!;

        public TypeEntity Damaging { get; set; } = null!;

        public string TargetId { get; set; } = null!;

        public TypeEntity Target { get; set; } = null!;

        public int Coefficient { get; set; }

        public TypeEfficiencyEntity() { }

        public TypeEfficiencyEntity(string damagingId, string targetId, int coefficient)
        {
            DamagingId = damagingId;
            TargetId = targetId;
            Coefficient = coefficient;
        }
    }
}
