using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    public interface ICurrentDateTimeService
    {
        /// <summary>
        /// Get the equivalent of <see cref="DateTime.Now"/>.
        /// </summary>
        /// <returns></returns>
        DateTime LocalNow();

        /// <summary>
        /// Get the equivalent of <see cref="DateTime.Today"/>.
        /// </summary>
        /// <returns></returns>
        DateTime LocalToday();

        /// <summary>
        /// Get the equivalent of <see cref="DateTime.UtcNow"/>.
        /// </summary>
        /// <returns></returns>
        DateTime UtcNow();
    }
}
