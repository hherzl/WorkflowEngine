using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WorkflowEngine.Designer.Responses;
using WorkflowEngine.Designer.ViewModels;
using WorkflowEngine.Model;

namespace WorkflowEngine.Designer.Controllers
{
    public partial class DesignerController : ApiController
    {
        // GET: api/Designer/Workflow
        [Route("Workflow")]
        public async Task<HttpResponseMessage> GetWorkflows()
        {
            var response = new ComposedModelResponse<WorkflowViewModel>() as IComposedModelResponse<WorkflowViewModel>;

            try
            {
                var model = await Task.Run(() =>
                {
                    return BusinessObject.GetWorkflows();
                });

                response.Model = model.Select(item => new WorkflowViewModel(item)).ToList();
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // GET: api/Designer/Workflow/5
        [Route("Workflow/{id}")]
        public async Task<HttpResponseMessage> GetWorkflow(Int32 id)
        {
            var response = new SingleModelResponse<WorkflowViewModel>() as ISingleModelResponse<WorkflowViewModel>;

            try
            {
                var model = await Task.Run(() =>
                {
                    return BusinessObject.GetWorkflow(new Workflow { ID = id });
                });

                response.Model = new WorkflowViewModel(model);
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // POST: api/Designer/Workflow
        [Route("Workflow")]
        public async Task<HttpResponseMessage> CreateWorkflow([FromBody]WorkflowViewModel value)
        {
            var response = new SingleModelResponse<WorkflowViewModel>() as ISingleModelResponse<WorkflowViewModel>;

            try
            {
                var model = await Task.Run(() =>
                {
                    return BusinessObject.AddWorkflow(value.ToEntity());
                });

                response.Model = new WorkflowViewModel(model);
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // PUT: api/Designer/Workflow/5
        [Route("Workflow")]
        public async Task<HttpResponseMessage> UpdateWorkflow(Int32 id, [FromBody]WorkflowViewModel value)
        {
            var response = new SingleModelResponse<WorkflowViewModel>() as ISingleModelResponse<WorkflowViewModel>;

            try
            {
                var model = await Task.Run(() =>
                {
                    return BusinessObject.UpdateWorkflow(id, value.ToEntity());
                });

                response.Model = new WorkflowViewModel(model);
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
