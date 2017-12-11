using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeHolding.ImageConverter.Interfaces
{
    /// <summary>
    /// Interface that the context should implement
    /// </summary>
    internal interface IContext
    {
        /// <summary>
        /// Method that the user should use to start the strategy
        /// </summary>
        void ExecuteStrategy();
    }
}
