using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WinSCP;

namespace Common.Extensions
{
    /// <summary>
    /// Extension methods related to the FtpService.
    /// </summary>
    internal static class FtpServiceHelperExtensions
    {
        /// <summary>
        /// Filters a string enumerable for valid paths.
        /// </summary>
        /// <param name="paths"></param>
        /// <returns></returns>
        internal static IList<string> WhereIsValidPath(this IEnumerable<string> paths)
        {
            return paths.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        }

        /// <summary>
        /// Get all files that match a given extension. If the extension is
        /// null or whitepace, get all files. No wildcard asterisk necessary.
        /// </summary>
        /// <param name="directoryInfo"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        internal static IEnumerable<FileInfo> GetFilesWithExtension(this DirectoryInfo directoryInfo, string extension)
        {
            if (directoryInfo == null) throw new ArgumentNullException(nameof(directoryInfo));

            if (string.IsNullOrWhiteSpace(extension))
            {
                return directoryInfo.GetFiles();
            }
            else
            {
                var wildCard = $"*{extension.Trim()}";
                return directoryInfo.GetFiles(wildCard);
            }
        }

        /// <summary>
        /// Check if a remote file has a given file extension.
        /// </summary>
        /// <param name="remoteFileInfo"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        internal static bool HasExtension(this RemoteFileInfo remoteFileInfo, string extension)
        {
            if (remoteFileInfo == null) throw new ArgumentNullException(nameof(remoteFileInfo));

            if (string.IsNullOrWhiteSpace(extension)) return true;

            extension = extension.Trim();

            if (extension.StartsWith("*") && extension.Length > 1)
            {
                extension = extension.Substring(1);
            }
            else if (extension == "*")
            {
                return true;
            }

            return remoteFileInfo.Name.EndsWith(extension, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
