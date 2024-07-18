using Context;
using Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class TypeEfficiencyRepository : ITypeEfficiencyService<TypeEfficiencyEntity>
    {
        private readonly PokemonDBContext _context;

        public TypeEfficiencyRepository(PokemonDBContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<float>> GetEfficiencyOn(string attackType, IEnumerable<string> targets)
        {
            return Task.Run(() => 
                _context.TypeEfficiencies
                .Where(te => te.DamagingId == attackType
                          && targets.Contains(te.TargetId))
                .Select(te => (float)te.Coefficient)
                .ToList().AsEnumerable()
            );
        }
    }
}
