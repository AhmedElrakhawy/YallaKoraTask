using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace YallaKora.Web.Controllers
{
    public class SharedController : Controller
    {
        private readonly IWebHostEnvironment _HostEnvironment; 

        public SharedController(IWebHostEnvironment HostEnvironment)
        {
            _HostEnvironment = HostEnvironment;
        }
        [HttpPost]
        public JsonResult UploadPictures()
        {
            //JsonData.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var Pictures = Request.Form.Files;
            var PicturesJson = new List<object>();
            for (int i = 0; i < Pictures.Count; i++)
            {
                var Picture = Pictures[i];
                var FileName = Guid.NewGuid() + Path.GetExtension(Picture.FileName);
                string webRootPath = _HostEnvironment.WebRootPath;
                string contentRootPath = _HostEnvironment.ContentRootPath;

                string path = "";
                path = Path.Combine(webRootPath, "Images");

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                var filePath = Path.Combine(path, FileName);

                using (FileStream fs = System.IO.File.Create(filePath))
                {
                    Picture.CopyTo(fs);

                }

                PicturesJson.Add(new { URL = FileName });
            }
            var JsonData = new JsonResult(PicturesJson);
            return Json(PicturesJson);
        }
    }
}
