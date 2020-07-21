using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Common.Utils
{
    public sealed class CryptoUtil
    {
        const string key = "081298448410812984489821";
        const string IV = "7982880798288512";

        public static string EncryptString(string str)
        {
            RijndaelManaged rmCrypto = new RijndaelManaged();
            MemoryStream memStream = new MemoryStream();

            byte[] keyBy = Encoding.ASCII.GetBytes(key);
            byte[] ivBy = Encoding.ASCII.GetBytes(IV);

            CryptoStream crypStream = new CryptoStream(memStream,
              rmCrypto.CreateEncryptor(keyBy, ivBy),
              CryptoStreamMode.Write);

            StreamWriter sWriter = new StreamWriter(crypStream);
            sWriter.Write(str);
            sWriter.Close();

            StringBuilder strBuilder = new StringBuilder();
            byte[] by = new byte[0];
            by = memStream.ToArray();

            for (int i = 0; i < by.Length; i++)
            {
                if (i != by.Length - 1)
                {
                    strBuilder.Append(by[i] + " ");
                }
                else
                {
                    strBuilder.Append(by[i]);
                }
            }

            return strBuilder.ToString();

        }

        public static string DecryptString(string str)
        {
            string[] arrStr = str.Split(' ');
            byte[] by = new byte[arrStr.Length];
            for (int i = 0; i < arrStr.Length; i++)
            {
                by[i] = Convert.ToByte(arrStr[i]);
            }

            RijndaelManaged rmCrypto = new RijndaelManaged();
            MemoryStream memStream = new MemoryStream(by);

            byte[] keyBy = Encoding.ASCII.GetBytes(key);
            byte[] ivBy = Encoding.ASCII.GetBytes(IV);

            CryptoStream crypStream = new CryptoStream(memStream,
              rmCrypto.CreateDecryptor(keyBy, ivBy),
              CryptoStreamMode.Read);

            StreamReader sReader = new StreamReader(crypStream);
            string result = sReader.ReadToEnd();
            sReader.Close();
            return result;
        }

    }
}
