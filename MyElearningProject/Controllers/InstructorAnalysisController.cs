using MyElearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class InstructorAnalysisController : Controller
    {
        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult InstructorPanelPartial()
		{
            string value = Session["CurrentMail"].ToString();//kullanıcının mailini alıyor
            int instructorID = context.Instructors.Where(x => x.Email == value).Select(y => y.InstructorID).FirstOrDefault();
            var values = context.Instructors.Where(x => x.InstructorID == instructorID).ToList();//kullanıcının tüm verilerini alıyor
            var v1 = context.Instructors.Where(x => x.InstructorID == instructorID).Select(y => y.InstructorID).FirstOrDefault();

            ViewBag.courseCount = context.Courses.Where(x => x.InstructorID == instructorID).Count();
            var v2 = context.Courses.Where(x => x.InstructorID == v1).Select(y => y.CourseID).ToList();
            ViewBag.commentCount = context.Comments.Where(x => v2.Contains(x.CourseID)).Count();
            ViewBag.averageCourseReview = 9.5;
            return PartialView(values);
           

        }
        public PartialViewResult CommentPartial()
		{
           
            string value = Session["CurrentMail"].ToString();
            int instructorID = context.Instructors.Where(x => x.Email == value).Select(y => y.InstructorID).FirstOrDefault();
            var v1 = context.Instructors.Where(x => x.InstructorID == instructorID).Select(y => y.InstructorID).FirstOrDefault();
            ViewBag.courseCount = context.Courses.Where(x => x.InstructorID == instructorID).Count();
            var v2 = context.Courses.Where(x => x.InstructorID == v1).Select(y => y.CourseID).ToList();
            ViewBag.commentCount = context.Comments.Where(x => v2.Contains(x.CourseID)).Count();
            var v3 = context.Comments.Where(x => v2.Contains(x.CourseID)).ToList();
            return PartialView(v3);
        }
     
        public PartialViewResult InstructorContactInformation()
		{
            string value = Session["CurrentMail"].ToString();
            int instructorID = context.Instructors.Where(x => x.Email == value).Select(y => y.InstructorID).FirstOrDefault();
            var values = context.Instructors.Where(x => x.InstructorID == instructorID).FirstOrDefault();
            return PartialView(values);
		}


    }
}