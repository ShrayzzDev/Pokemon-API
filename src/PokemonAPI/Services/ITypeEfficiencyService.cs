using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ITypeEfficiencyService<T> where T : class
    {
        /// <summary>
        /// Gets the damage coefficients 
        /// </summary>
        /// <param name="attackType">Type of the attack.</param>
        /// <param name="targets">Types recieving the attack.</param>
        /// <returns></returns>
        public Task<IEnumerable<float>> GetEfficiencyOn(string attackType, IEnumerable<string> targets);
    }
}
