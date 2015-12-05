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
using WorkflowEngine.Model;

namespace WorkflowEngine.Designer.Controllers
{
    public class WorkflowBatchController : ApiController
    {
        protected IWorkflowManagerUow Uow;

        public WorkflowBatchController(IUowService service)
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

        // GET: api/WorkflowBatch
        public async Task<HttpResponseMessage> Get()
        {
            var response = new WorkflowBatchComposedResponse();

            try
            {
                response.Model = await Task.Run(() =>
                {
                    return Uow
                        .WorkflowBatchRepository
                        .GetAll()
                        .Select(item => new WorkflowBatchViewModel
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

        // GET: api/WorkflowBatch/5
        public async Task<HttpResponseMessage> Get(Int32 id)
        {
            var response = new WorkflowBatchSingleResponse();

            try
            {
                var entity = await Task.Run(() =>
                {
                    return Uow.WorkflowBatchRepository.Get(new WorkflowBatch { ID = id });
                });

                response.Model = new WorkflowBatchViewModel(entity);
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // POST: api/WorkflowBatch
        public async Task <HttpResponseMessage> Post([FromBody]WorkflowBatchViewModel value)
        {
            var response = new WorkflowBatchSingleResponse();

            try
            {
                var entity = new WorkflowBatch
                {
                    Name = value.Name,
                    Description = value.Description
                };

                Uow.WorkflowBatchRepository.Add(entity);

                await Uow.CommitChangesAsync();

                response.Model = new WorkflowBatchViewModel(entity);
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // PUT: api/WorkflowBatch/5
        public async Task<HttpResponseMessage> Put(Int32 id, [FromBody]WorkflowBatchViewModel value)
        {
            var response = new WorkflowBatchSingleResponse();

            try
            {
                var entity = await Task.Run(() =>
                {
                    return Uow.WorkflowBatchRepository.Get(new WorkflowBatch { ID = id });
                });

                entity.Name = value.Name;
                entity.Description = value.Description;

                await Uow.CommitChangesAsync();

                response.Model = new WorkflowBatchViewModel(entity);
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // DELETE: api/WorkflowBatch/5
        public async Task<HttpResponseMessage> Delete(Int32 id)
        {
            var response = new WorkflowBatchSingleResponse();

            try
            {
                var entity = await Task.Run(() =>
                {
                    return Uow.WorkflowBatchRepository.Get(new WorkflowBatch { ID = id });
                });

                Uow.WorkflowBatchRepository.Delete(entity);

                await Uow.CommitChangesAsync();

                response.Model = new WorkflowBatchViewModel(entity);
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
