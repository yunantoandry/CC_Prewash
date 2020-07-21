using System.Collections.Generic;
using System.Linq;

namespace Common.Utils
{
    public static class StringExtensions
    {
        public static string ToNullIfWhitespace(this string src)
        {
            return string.IsNullOrWhiteSpace(src) ? null : src;
        }

        public static string ToSpacelessCsv(this IEnumerable<string> strings)
        {
            if (strings == null) return "";
            return string.Join(",", strings);
        }

        public static string ToCsv(this IEnumerable<string> strings, int? limit = null)
        {
            if (strings == null) return "";

            if (limit <= 0)
            {
                return ""; 
            }

            if (limit != null)
            {
                var someStrings = strings.Take(limit.Value);

                var itemsRemainingCount = strings.Count() - someStrings.Count();

                if (itemsRemainingCount > 0)
                {
                    return $"{string.Join(", ", someStrings)} (and {itemsRemainingCount} others)";
                }
            }
            return string.Join(", ", strings);
        }
    }
}
