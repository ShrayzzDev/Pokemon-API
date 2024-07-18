using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// Interface that defines method needed to calculate
    /// damages.
    /// </summary>
    /// <typeparam name="T">Damage Parameters</typeparam>
    public interface IDamageCalculator<T> where T : class 
    {
        /// <summary>
        /// Calculate damages
        /// </summary>
        /// <param name="informations">Parameters used for calculation</param>
        /// <returns>A tuple of double, first is the minimum roll second is the max roll</returns>
        public Task<(double,double)> GetDamage(T informations);

        /// <summary>
        /// Calculate the concrete stat value used
        /// for calculations.
        /// </summary>
        /// <param name="bst">Base stat</param>
        /// <param name="evs">Amount of evs</param>
        /// <param name="ivs">Amount of ivs</param>
        /// <param name="level">Level of the pokemon</param>
        /// <returns>Real value</returns>
        protected int EffectiveStat(int bst, int evs, int ivs, int level, bool isHp);
    }
}
