using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class InstructorController : Controller
    {
        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            
            var values = context.Instructors.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddInstructor()
		{
            return View();
		}
        [HttpPost]
        public ActionResult AddInstructor(Instructor instructor)
        {
            context.Instructors.Add(instructor);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteInstructor(int id)
		{
            var values = context.Instructors.Find(id);
            context.Instructors.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
		}
        [HttpGet]
        public ActionResult UpdateInstructor(int id)
        {
            var values = context.Instructors.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateInstructor(Instructor instructor)
        {
            var values = context.Instructors.Find(instructor.InstructorID);
            values.Name = instructor.Name;
            values.Surname = instructor.Surname;
            values.ImageUrl = instructor.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}