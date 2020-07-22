using Common.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    public class CreateFiles
    {
        public static void CreateFile(string fullPath, string data)
        {
            data = data.Replace("utf-16", "utf-8");
            using (StreamWriter sw = new StreamWriter(fullPath))
            {
                sw.Write(data);
            }
        }

        public static void CreateFileList(string fullPath, List<tr_xml_trans> listXmlTranResponse)
        {

            using (StreamWriter sw = new StreamWriter(fullPath))
            {
                foreach (var item in listXmlTranResponse)
                {
                    string wr = item.XML_RESPONSE;
                    wr = wr.Replace("utf-16", "utf-8");
                    sw.Flush();
                    sw.Write(wr);
                }
            }
        }
    }
}
