using System;

namespace WorkflowEngine.Model.Serialization
{
    public interface ISerializer
    {
        String Serialize(Object obj);

        T Deserialize<T>(String xml) where T : new();
    }
}
