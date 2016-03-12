using System;
using System.IO;
using System.Xml.Serialization;

namespace WorkflowEngine.Model.Serialization
{
    public class XmlSerializerImplementation : ISerializer
    {
        public XmlSerializerImplementation()
        {

        }

        public String Serialize(Object obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());

            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, obj);

                return writer.ToString();
            }
        }

        public T Deserialize<T>(String xml) where T : new()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (StringReader reader = new StringReader(xml))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
