using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WorkflowEngine.Designer.Models;
using WorkflowEngine.Designer.Models.Contracts;
using WorkflowEngine.Designer.Responses;
using WorkflowEngine.Designer.Services;
using WorkflowEngine.Designer.ViewModels;
using WorkflowEngine.Model;

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
        public async Task<HttpResponseMessage> Get(Int32 id)
        {
            var response = new WorkflowSingleResponse();

            try
            {
                var entity = await Task.Run(() =>
                {
                    return Uow.WorkflowRepository.Get(new Workflow { ID = id });
                });

                response.Model = new WorkflowViewModel(entity);
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // POST: api/Workflow
        public async Task <HttpResponseMessage> Post([FromBody]WorkflowViewModel value)
        {
            var response = new WorkflowSingleResponse();

            try
            {
                var entity = new Workflow
                {
                    Name = value.Name,
                    Description = value.Description
                };

                Uow.WorkflowRepository.Add(entity);

                await Uow.CommitChangesAsync();

                response.Model = new WorkflowViewModel(entity);
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // PUT: api/Workflow/5
        public async Task<HttpResponseMessage> Put(Int32 id, [FromBody]WorkflowViewModel value)
        {
            var response = new WorkflowSingleResponse();

            try
            {
                var entity = await Task.Run(() =>
                {
                    return Uow.WorkflowRepository.Get(new Workflow { ID = id });
                });

                entity.Name = value.Name;
                entity.Description = value.Description;

                await Uow.CommitChangesAsync();

                response.Model = new WorkflowViewModel(entity);
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // DELETE: api/Workflow/5
        public void Delete(Int32 id)
        {
        }
    }
}
