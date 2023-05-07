using Banner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Banner.Controllers
{
    public class BannerController : ApiController
    {
        ContextBannerDB db = new ContextBannerDB();
        // GET: api/Banner 

        [HttpGet]
        public List<BannerModel> Get()
        {
            return db.Get().ToList();
        }

        // GET: api/Banner/5
        public BannerModel Get(int id)
        {
          return db.Get().Where(model => model.banner_id == id).FirstOrDefault();
        }

        // POST: api/Banner
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Banner/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Banner/5
        public void Delete(int id)
        {
        }
    }
}
