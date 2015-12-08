﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WorkflowEngine.Designer.Models.Contracts;
using WorkflowEngine.Designer.Responses;
using WorkflowEngine.Designer.Services;
using WorkflowEngine.Designer.ViewModels;

namespace WorkflowEngine.Designer.Controllers
{
    public class WorkflowConstantController : ApiController
    {
        protected IWorkflowManagerUow Uow;

        public WorkflowConstantController(IUowService service)
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

        // GET: api/WorkflowConstant
        public async Task<HttpResponseMessage> Get()
        {
            var response = new WorkflowConstantComposedResponse();

            try
            {
                response.Model = await Task.Run(() =>
                {
                    return Uow
                        .WorkflowConstantRepository
                        .GetAll()
                        .Select(item => new WorkflowConstantViewModel(item))
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

        // GET: api/WorkflowConstant/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/WorkflowConstant
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/WorkflowConstant/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/WorkflowConstant/5
        public void Delete(int id)
        {
        }
    }
}
