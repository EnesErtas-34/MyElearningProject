using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class InstructorProfileController : Controller
    {
        // GET: InstructorProfile
        ELearningContext context = new ELearningContext();
        [HttpGet]
        public ActionResult Index()
        {
            TempData["Location"] = "Profil";
            string value = Session["CurrentMail"].ToString();
            int instructorID = context.Instructors.Where(x => x.Email == value).Select(y => y.InstructorID).FirstOrDefault();
            var instructorInformations = context.Instructors.Where(x => x.InstructorID == instructorID).FirstOrDefault();
            return View(instructorInformations);
        }
        [HttpPost]
        public ActionResult Index(Instructor instructor)
        {
            var value = context.Instructors.Find(instructor.InstructorID);
            value.Title = instructor.Title;
            value.Name = instructor.Name;
            value.Surname = instructor.Surname;
            value.ImageUrl = instructor.ImageUrl;
            value.CoverImage = instructor.CoverImage;
            value.Email = instructor.Email;
            value.Password = instructor.Password;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}