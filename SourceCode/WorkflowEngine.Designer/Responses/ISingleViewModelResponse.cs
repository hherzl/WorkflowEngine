namespace WorkflowEngine.Designer.Responses
{
    public interface ISingleViewModelResponse<TModel> : IViewModelResponse
    {
        TModel Model { get; set; }
    }
}
