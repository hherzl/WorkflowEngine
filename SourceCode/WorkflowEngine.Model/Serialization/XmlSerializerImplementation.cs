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

        public String FileExtension
        {
            get
            {
                return "xml";
            }
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

        public void SerializeTo(String path, Object obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());

            String content = String.Empty;

            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, obj);

                content = writer.ToString();
            }

            File.WriteAllText(path, content);
        }

        public T Deserialize<T>(String xml) where T : new()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (StringReader reader = new StringReader(xml))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        public T DeserializeFrom<T>(String path) where T : new()
        {
            String content = File.ReadAllText(path);

            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (StringReader reader = new StringReader(content))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
