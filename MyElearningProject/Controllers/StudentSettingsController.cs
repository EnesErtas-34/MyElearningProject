using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class StudentSettingsController : Controller
    {
        ELearningContext context = new ELearningContext();
        [HttpGet]
        public ActionResult Index()
        {
            TempData["location"] = "Öğrenci Ayarlar";
            string value=Session["CurrentMail"].ToString();
            int studentID = context.Students.Where(x => x.Email == value).Select(y => y.StudentID).FirstOrDefault();
            var studentInformations = context.Students.Where(x => x.StudentID == studentID).FirstOrDefault();
            return View(studentInformations);
        }
        [HttpPost]
        public ActionResult Index(Student student)
		{
            var values = context.Students.Find(student.StudentID);
            values.Name = student.Name;
            values.Surname = student.Surname;
            values.Email = student.Email;
            values.Password = student.Password;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}