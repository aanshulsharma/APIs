using Banner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Banner.Controllers
{
    public class BrandController : ApiController
    {
        ContextBrandDB db = new ContextBrandDB(); 
        // GET: api/Brand
        public IEnumerable<BrandModel> Get()
        {
            return db.Get().ToList();
        }

        // GET: api/Brand/5
        public BrandModel Get(int id)
        {

            return db.Get().Where(model => model.BrandId == id).FirstOrDefault();
            
        }

        // POST: api/Brand
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Brand/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Brand/5
        public void Delete(int id)
        {
        }
    }
}
