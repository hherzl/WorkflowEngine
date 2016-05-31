using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WorkflowEngine.Designer.Responses;
using WorkflowEngine.Designer.ViewModels;

namespace WorkflowEngine.Designer.Controllers
{
    public partial class DesignerController : ApiController
    {
        // GET: api/Designer/WorkflowTask
        [Route("WorkflowTask")]
        public async Task<HttpResponseMessage> GetWorkflowTasks()
        {
            var response = new ComposedModelResponse<WorkflowTaskViewModel>() as IComposedModelResponse<WorkflowTaskViewModel>;

            try
            {
                var model = await Task.Run(() =>
                {
                    return BusinessObject.GetWorkflowTasks();
                });

                response.Model = model.Select(item => new WorkflowTaskViewModel(item)).ToList();
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }
    }
}
