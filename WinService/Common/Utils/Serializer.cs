using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Common.Utils
{
    public class Serializer
    {
        public string DataTableToJSONWithJavaScriptSerializer(DataTable table)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            return jsSerializer.Serialize(parentRow);
        }

        public T Deserialize<T>(string input) where T : class
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));

            using (StringReader sr = new StringReader(input))
            {
                return (T)ser.Deserialize(sr);
            }
        }

        //public string Serialize<T>(T ObjectToSerialize)
        //{
        //    XmlSerializer xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());

        //    using (StringWriter textWriter = new StringWriter())
        //    {
        //        xmlSerializer.Serialize(textWriter, ObjectToSerialize);
        //        return textWriter.ToString();
        //    }
        //}

        public string Serialize<T>(T ObjectToSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    XmlSerializerNamespaces names = new XmlSerializerNamespaces();
                    names.Add("", "");
                    xmlSerializer.Serialize(xmlWriter, ObjectToSerialize, names);
                    return textWriter.ToString();
                }
                
            }
        }

        public static void Serialize<T>(T obj, string filepath)
        {
            var writer = new StreamWriter(filepath);
            Serialize<T>(obj, writer);
        }

        public static void Serialize<T>(T obj, TextWriter writer)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            XmlWriter xmlWriter = XmlWriter.Create(writer, settings);
            XmlSerializerNamespaces names = new XmlSerializerNamespaces();
            names.Add("", "");
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(xmlWriter, obj, names);
        }
    }
}
