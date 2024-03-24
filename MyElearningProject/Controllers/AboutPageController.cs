using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class AboutPageController : Controller
    {
        // GET: AboutPage
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PagePartial()
		{
            return PartialView();
		}
    }
}