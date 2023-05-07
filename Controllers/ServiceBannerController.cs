using Banner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Banner.Models
{
    public class ServiceBannerController : ApiController
    {
        ServiceBannerDB db = new ServiceBannerDB();
        // GET: api/ServiceBanner
        public IEnumerable<ServiceBanner> Get()
        {
            return db.Get().ToList();
        }

        // GET: api/ServiceBanner/5
        public ServiceBanner Get(int id)
        {
            return db.Get().FirstOrDefault(model => model.BannerId == id);
        }

        // POST: api/ServiceBanner
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ServiceBanner/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ServiceBanner/5
        public void Delete(int id)
        {
        }
    }
}
