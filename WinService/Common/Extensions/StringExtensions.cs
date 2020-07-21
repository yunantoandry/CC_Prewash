using System;
using System.IO;
using System.Text;

namespace Common.Extensions
{
    /// <summary>
    /// Provides a set of static methods for manipulating <see cref="string"/>.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts a potential path to use forward slashes.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToUnixPath(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return str;

            return str.Replace("\\", "/");
        }

        /// <summary>
        /// Converts a potential path to use backslashes.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToWindowsPath(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return str;

            return str.Replace("/", "\\");
        }

        /// <summary>
        /// Checks if a string is not null or whitespace.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNotWhitespace(this string str)
        {
            return !string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// Given a string, if it is null or whitespace, return a dash, Else,
        /// return itself.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToStringOrDash(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return "-";
            }

            return str;
        }

        /// <summary>
        /// Given a string, if it is null or whitespace, return null. Else,
        /// return the string as is.
        /// </summary>
        /// <returns></returns>
        public static string ToNullIfWhitespace(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }

            return str.Trim();
        }

        /// <summary>
        /// Convert a string into a unicode stream.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Stream ToUnicodeStream(this string str)
        {
            if (str == null) throw new ArgumentNullException(nameof(str));

            var unicodeEncoding = new UnicodeEncoding();
            var unicodeBytes = unicodeEncoding.GetBytes(str);

            return new MemoryStream(unicodeBytes);
        }
    }
}
