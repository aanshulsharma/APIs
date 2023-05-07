using Banner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Banner.Controllers
{
    public class ServiceController : ApiController
    {
        ContextServiceDB db = new ContextServiceDB();
        // GET: api/Service
        public IEnumerable<ServiceModel> Get()
        {
            return db.Get().ToList();
        }

        // GET: api/Service/5
        public ServiceModel Get(int id)
        {
            return db.Get().Where(model => model.Id == id).FirstOrDefault();
        }

        // POST: api/Service
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Service/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Service/5
        public void Delete(int id)
        {
        }
    }
}
