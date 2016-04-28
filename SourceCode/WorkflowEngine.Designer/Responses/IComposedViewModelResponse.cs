using System.Collections.Generic;

namespace WorkflowEngine.Designer.Responses
{
    public interface IComposedViewModelResponse<TModel> : IViewModelResponse
    {
        IEnumerable<TModel> Model { get; set; }
    }
}
