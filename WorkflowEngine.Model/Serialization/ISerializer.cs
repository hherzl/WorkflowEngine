using System;

namespace WorkflowEngine.Model.Serialization
{
    public interface ISerializer
    {
        String FileExtension { get; }
        
        String Serialize(Object obj);

        void SerializeTo(String path, Object obj);

        T Deserialize<T>(String xml) where T : new();

        T DeserializeFrom<T>(String path) where T : new();
    }
}
