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
        // GET: api/Designer/WorkflowConstant
        [Route("WorkflowConstant")]
        public async Task<HttpResponseMessage> GetWorkflowConstants()
        {
            var response = new ComposedModelResponse<WorkflowConstantViewModel>() as IComposedModelResponse<WorkflowConstantViewModel>;

            try
            {
                var model = await Task.Run(() =>
                {
                    return BusinessObject.GetWorkflowConstants();
                });

                response.Model = model.Select(item => new WorkflowConstantViewModel(item)).ToList();
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
