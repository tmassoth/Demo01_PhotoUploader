using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo01_PhotoDisplayer.Models
{
    public class DisplayController : Controller
    {
        // GET: Display
        public ActionResult Index()
        {
            return View();
        }
    }
}