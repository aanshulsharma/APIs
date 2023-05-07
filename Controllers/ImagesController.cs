using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Banner.Controllers
{
    public class ImagesController : ApiController
    {
        [Route("api/Images/PostImage")]
        [HttpPost]
        public IHttpActionResult PostImage()
        {
            if (HttpContext.Current.Request.Files.Count == 0)
            {
                return BadRequest("No files were uploaded.");
            }

            var file = HttpContext.Current.Request.Files[0];
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            var directory = HttpContext.Current.Server.MapPath("~/Images");
            var path = Path.Combine(directory, fileName);

            try
            {
                file.SaveAs(path);
                var imageUrl = $"{Request.RequestUri.Scheme}://{Request.RequestUri.Authority}/Images/{fileName}";
                return Ok(imageUrl);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
