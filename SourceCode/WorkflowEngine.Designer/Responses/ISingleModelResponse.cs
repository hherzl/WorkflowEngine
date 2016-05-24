namespace WorkflowEngine.Designer.Responses
{
    public interface ISingleModelResponse<TModel> : IModelResponse
    {
        TModel Model { get; set; }
    }
}
