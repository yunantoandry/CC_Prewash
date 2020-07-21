using Common;
using System.Collections.Generic;
using System.Linq;

namespace Common.Utils
{
    /// <summary>
    /// A parser that handles database columns that were not normalized.
    /// </summary>
    public static class MultiValueColumnParser
    {
        /// <summary>
        /// Given a string from a column that was not normalized, split it
        /// using the standard multivalued column seperator. If the string is
        /// null or empty, return an empty list.
        /// </summary>
        public static IList<string> TryParse(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return new List<string>();
            }

            return str.Split(Constants.MultivalueColumnSeparator)
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();
        }
    }
}
