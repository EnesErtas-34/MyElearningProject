using MyElearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class MessageController : Controller
    {
        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            var values=context.Messages.ToList();
            return View(values);
        }
        public ActionResult DeleteMessage(int id)
		{
            var values = context.Messages.Find(id);
            context.Messages.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");

		}
    }
}