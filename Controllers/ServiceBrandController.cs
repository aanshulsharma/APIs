using Banner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Banner.Controllers
{
    public class ServiceBrandController : ApiController
    {
        ServiceBrandDB db = new ServiceBrandDB();
        // GET: api/ServiceBrand
        public IEnumerable<ServiceBrand> Get()
        {
            return db.Get().ToList();
        }

        // GET: api/ServiceBrand/5
        public ServiceBrand Get(int id)
        {
            return db.Get().Where(model => model.BrandId == id).FirstOrDefault();
        }

        // POST: api/ServiceBrand
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ServiceBrand/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ServiceBrand/5
        public void Delete(int id)
        {
        }
    }
}
