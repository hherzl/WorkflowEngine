using System.Collections.Generic;

namespace WorkflowEngine.Designer.Responses
{
    public interface IComposedModelResponse<TModel> : IModelResponse
    {
        IEnumerable<TModel> Model { get; set; }
    }
}
