using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class DefaultController : Controller
    {
        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult FeaturePartial()
		{
            var values = context.DefaultFeatures.ToList();
            return PartialView(values);
		}
        public PartialViewResult ServicePartial()
        {
            var values = context.AboutFeatures.ToList();
            return PartialView(values);
        }
        public PartialViewResult AboutPartial()
		{
            var values = context.Abouts.ToList();
            return PartialView(values);
		}
        public PartialViewResult CategoryPartial()
        {
            var values = context.Courses.ToList();
            ViewBag.v1 = context.Courses.Where(x => x.CourseID == 1).Select(y => y.Title).FirstOrDefault();
            ViewBag.v2 = context.Courses.Where(x => x.CourseID == 2).Select(y => y.Title).FirstOrDefault();
			ViewBag.v3 = context.Courses.Where(x => x.CourseID == 3).Select(y => y.Title).FirstOrDefault();
			ViewBag.v4 = context.Courses.Where(x => x.CourseID == 5).Select(y => y.Title).FirstOrDefault();
			return PartialView(values);
        }
        public PartialViewResult CoursePartial()
        {
            var values = context.Courses.OrderByDescending(x=>x.CourseID).Take(3).ToList();
            return PartialView(values);
        }
        public PartialViewResult TeamPartial()
        {
            var values = context.Instructors.ToList();
            return PartialView(values);
        }
        public PartialViewResult TestimonialPartial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }

		[HttpGet]
		public PartialViewResult Subscribe()
		{

			return PartialView();
		}
		[HttpPost]
		public ActionResult Subscribe(Subscribe subscribe)
		{
			 context.Subscribes.Add(subscribe);
            context.SaveChanges();
			return RedirectToAction("Index","Default");
		}
	}
}