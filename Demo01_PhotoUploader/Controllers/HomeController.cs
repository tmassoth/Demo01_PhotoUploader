using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo01_PhotoDisplayer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Index(HttpPostedFileBase uploadedFile)
        {
            if (uploadedFile != null)
            {
                string fileName = Path.GetFileName(uploadedFile.FileName);
                string fileExtension = Path.GetExtension(uploadedFile.FileName);

                if (fileExtension.ToUpper().Contains(".JPG") || 
                    fileExtension.ToUpper().Contains(".JPEG") || 
                    fileExtension.ToUpper().Contains(".GIF") || 
                    fileExtension.ToUpper().Contains(".TIFF") || 
                    fileExtension.ToUpper().Contains(".TIF") || 
                    fileExtension.ToUpper().Contains(".PNG")
                    )
                {
                    string path = Server.MapPath("~/Uploads/");

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    uploadedFile.SaveAs(path + fileName);
                    ViewBag.ImageUrl = "Uploads/" + fileName;
                }
                else
                {
                    ViewBag.ImageUrl = null;
                    ViewBag.filename = fileName;
                }
            }

            return View();
        }
    }
}