using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WorkflowEngine.Designer.Responses;

namespace WorkflowEngine.Designer.Controllers
{
    public class DesignerController : ApiController
    {
        public DesignerController()
        {

        }

        // GET: api/Designer
        public async Task<HttpResponseMessage> Get()
        {
            var response = new DesignerComposedResponse();

            try
            {

            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // GET: api/Designer/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Designer
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Designer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Designer/5
        public void Delete(int id)
        {
        }
    }
}
