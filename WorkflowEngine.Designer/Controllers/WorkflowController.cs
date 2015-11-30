using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WorkflowEngine.Designer.Models;
using WorkflowEngine.Designer.Responses;
using WorkflowEngine.Designer.Services;
using WorkflowEngine.Designer.ViewModels;

namespace WorkflowEngine.Designer.Controllers
{
    public class WorkflowController : ApiController
    {
        protected IWorkflowManagerUow Uow;

        public WorkflowController(IUowService service)
        {
            Uow = service.GetWorkflowManagerUow();
        }

        protected override void Dispose(bool disposing)
        {
            if (Uow != null)
            {

            }

            base.Dispose(disposing);
        }

        // GET: api/Workflow
        public async Task<HttpResponseMessage> Get()
        {
            var response = new WorkflowComposedResponse();

            try
            {
                response.Model = await Task.Run(() =>
                {
                    return Uow
                        .WorkflowRepository
                        .GetAll()
                        .Select(item => new WorkflowViewModel
                        {
                            ID = item.ID,
                            Name = item.Name,
                            Description = item.Description
                        })
                        .ToList();
                });
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // GET: api/Workflow/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Workflow
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Workflow/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Workflow/5
        public void Delete(int id)
        {
        }
    }
}
