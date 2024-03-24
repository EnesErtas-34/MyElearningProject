using MyElearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class CoursePageController : Controller
    {
        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            return View();
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
            return PartialView();
        }
    }
}