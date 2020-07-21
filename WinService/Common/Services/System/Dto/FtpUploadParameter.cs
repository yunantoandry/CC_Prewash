using System;
using System.Linq;

namespace Common.Services.System.Dto
{
    /// <summary>
    /// This DTO represents a DB row that contains a string like this
    /// 
    /// "C:/folder_on_your_computer;/folder_on_ftp_server"
    /// 
    /// Which is used to configure the source and destination for FTP uploads
    /// from the server this app is installed in to another server.
    /// 
    /// Please do not create multivalued columns in the future.
    /// </summary>
    public class FtpUploadParameter
    {
        public string Source { get; private set; }
        public string Destination { get; private set; }

        public FtpUploadParameter(string register)
        {
            var ftpPathSeperatorCharacter = Constants.MultivalueColumnSeparator;

            if (string.IsNullOrWhiteSpace(register))
            {
                throw new ArgumentException($"Cannot parse the given string into a'{nameof(FtpUploadParameter)}' because the source string is null or whitespace.");
            }

            var paths = register.Split(ftpPathSeperatorCharacter);

            if (paths.Count() <= 1)
            {
                throw new ArgumentException($"Cannot parse the string '{register}' into a '{nameof(FtpUploadParameter)}' because the source string only has one element. It needs two elemenets seperated by '{ftpPathSeperatorCharacter}', the first being the source and the second being the destination.");
            }
            else if (paths.Count() > 2)
            {
                throw new ArgumentException($"Cannot parse the string '{register}' into a '{nameof(FtpUploadParameter)}' because the source string has more than on element. It needs two elemenets seperated by '{ftpPathSeperatorCharacter}', the first being the source and the second being the destination.");
            }
            else
            {
                Source = paths[0];
                Destination = paths[1];
            }
        }
    }
}
