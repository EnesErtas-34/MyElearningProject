using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class ContactPageController : Controller
    {
        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult ContactUsPartial()
		{
            var values = context.Addresses.ToList();
            return PartialView(values);
		}
        [HttpGet]
        public PartialViewResult SendMessage()
		{
            return PartialView();
		}
        [HttpPost]
        public ActionResult SendMessage(Message message)
		{
            context.Messages.Add(message);
            context.SaveChanges();
            return RedirectToAction("Index","ContactPage");
		}
        public PartialViewResult ContactPage()
		{
            return PartialView();
		}
    }
}