using log4net;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace Common.Utils
{
    /// <summary>
    /// Helper methods for file system related tasks.
    /// </summary>
    public static class FileSystemUtil
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(FileSystemUtil));

        public static string ReplaceSubPath(string originalFilePath, string subPathToReplace, string newSubPath)
        {
            if (string.IsNullOrWhiteSpace(originalFilePath))
            {
                return originalFilePath;
            }

            if (string.IsNullOrWhiteSpace(subPathToReplace))
            {
                return originalFilePath;
            }

            subPathToReplace = subPathToReplace.Trim();
            newSubPath = newSubPath ?? "";
            newSubPath = newSubPath.Trim();

            return Regex.Replace
                (originalFilePath,
                Regex.Escape(subPathToReplace),
                newSubPath, 
                RegexOptions.IgnoreCase
            );
        }

        /// <summary>
        /// Checks if a file is in use.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool IsFileInUse(string filePath)
        {
            return IsFileInUse(new FileInfo(filePath));
        }

        /// <summary>
        /// Checks if a file is in use.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool IsFileInUse(FileInfo file)
        {
            FileStream stream = null;
            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException ex)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return false;
        }

        public static string TryReadPotentiallyInUseFile(string fullPath)
        {
            string result = string.Empty;

            while (IsFileInUse(new FileInfo(fullPath)))
            {
                //loop until filehandle is released
                Thread.Sleep(500);
            }
            try
            {
                result = File.ReadAllText(fullPath);
            }
            catch (Exception ex)
            {
                result = string.Empty;
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Given a path, create both its folder and the file.
        /// If the folder already exists, just create the file.
        /// </summary>
        /// <param name="originalFilePath"></param>
        /// <param name="data"></param>
        public static void CreateDirectoryAndCopyFile(string originalFilePath, string newFilePath)
        {
            var newFileParentFolder = Path.GetDirectoryName(newFilePath);

            if (!Directory.Exists(newFileParentFolder))
            {
                Directory.CreateDirectory(newFileParentFolder);
            }

            _log.Debug($"Creating and copying directory and file '{originalFilePath}' to '{newFilePath}'.");

            File.Copy(originalFilePath, newFilePath, true);
        }

        /// <summary>
        /// Given a path, create both its folder and the file.
        /// If the folder already exists, just create the file.
        /// </summary>
        /// <param name="originalFilePath"></param>
        /// <param name="data"></param>
        public static void CreateDirectoryAndMoveFile(string originalFilePath, string newFilePath)
        {
            var newFileParentFolder = Path.GetDirectoryName(newFilePath);

            if (!Directory.Exists(newFileParentFolder))
            {
                Directory.CreateDirectory(newFileParentFolder);
            }

            _log.Debug($"Creating and moving directory and file '{originalFilePath}' to '{newFilePath}'.");

            File.Move(originalFilePath, newFilePath);
        }

        /// <summary>
        /// Given a path, create both its folder and the file.
        /// If the folder already exists, just create the file.
        /// </summary>
        /// <param name="fullPath"></param>
        /// <param name="data"></param>
        public static void CreateDirectoryAndFile(string fullPath, string data)
        {
            var parentFolder = Path.GetDirectoryName(fullPath);

            if (!Directory.Exists(parentFolder))
            {
                Directory.CreateDirectory(parentFolder);
            }

            data = data.Replace("utf-16", "utf-8");

            using (var sw = new StreamWriter(fullPath))
            {
                sw.Write(data);
            }
        }

        public static void MoveFilesFromFolder(
            string sourceFolder,
            string destinationFolder
        )
        {
            CutOrCopyFilesFromFolder(
                sourceFolder,
                destinationFolder,
                shouldCut: true
            );
        }

        public static void CopyFilesFromFolder(
            string sourceFolder,
            string destinationFolder
        )
        {
            CutOrCopyFilesFromFolder(
                sourceFolder,
                destinationFolder,
                shouldCut: false
            );
        }

        private static void CutOrCopyFilesFromFolder(
            string sourceFolder,
            string destinationFolder,
            bool shouldCut
        )
        {
            if (sourceFolder == null) throw new ArgumentNullException(nameof(sourceFolder));
            if (destinationFolder == null) throw new ArgumentNullException(nameof(destinationFolder));

            var sourceFiles = Directory.GetFiles(sourceFolder, "*", SearchOption.AllDirectories);

            foreach (var sourceFile in sourceFiles)
            {
                try
                {
                    if (!IsFileInUse(sourceFile))
                    {
                        var destinationFilePath = ReplaceSubPath(
                            sourceFile,
                            sourceFolder,
                            destinationFolder
                        );

                        if (File.Exists(destinationFilePath))
                        {
                            File.Delete(destinationFilePath);
                        }

                        if (shouldCut)
                        {
                            _log.Debug($"Cutting '{sourceFile}' to '{destinationFilePath}'.");
                            CreateDirectoryAndMoveFile(sourceFile, destinationFilePath);
                        }
                        else 
                        {
                          //  _log.Debug($"Copying '{sourceFile}' to '{destinationFilePath}'.");
                            CreateDirectoryAndCopyFile(sourceFile, destinationFilePath);
                        }
                    }
                    else
                    {
                        _log.Debug($"File '{sourceFile}' is in use and cannot be moved.");
                    }
                }
                catch (Exception ex)
                {
                    _log.Error(ex);
                }
            }
        }
    }
}
