using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace ComputeCommon.Common
{
    public class SerializerHelper
    {
        public static void XMLSerialize(string fileName,object sourceObject)
        {
            try
            {
                if (File.Exists(fileName))
                    File.Delete(fileName);

                XmlSerializer serializer = new XmlSerializer(sourceObject.GetType());
                TextWriter writer = new StreamWriter(fileName);
                serializer.Serialize(writer, sourceObject);
                writer.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static T XMLDeSerialize<T>(string fileName) where T:new()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    return (T)serializer.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
