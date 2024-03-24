using MyElearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class AdminLayoutController : Controller
    {
        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
		{
            return PartialView();
		}
        public PartialViewResult PartialSidebar()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            string value = Session["CurrentMail"].ToString();
            ViewBag.adminUserName = value;
            int id = context.Admins.Where(x => x.Username == value).Select(y => y.AdminID).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialRowPageTitle()
        {
            return PartialView();
        }
        public PartialViewResult PartialPreloader()
        {
            return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
    }
}