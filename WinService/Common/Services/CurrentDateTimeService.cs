using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    //https://stackoverflow.com/questions/7851554/abstracting-the-datetime-current-dependency

    //TODO: There's still incorrect code that uses DateTime.Now, making testing
    //harder. Cosnider replacing them with this.

    /// <summary>
    /// Abstraction of DateTime.Now for making testing easier.
    /// </summary>
    public class CurrentDateTimeService : ICurrentDateTimeService
    {
        /// <summary>
        /// Get the equivalent of <see cref="DateTime.Today"/>.
        /// </summary>
        /// <returns></returns>
        public DateTime LocalToday()
        {
            return DateTime.Today;
        }

        /// <summary>
        /// Get the equivalent of <see cref="DateTime.Now"/>.
        /// </summary>
        /// <returns></returns>
        public DateTime LocalNow()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// Get the equivalent of <see cref="DateTime.UtcNow"/>.
        /// </summary>
        /// <returns></returns>
        public DateTime UtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}
