﻿using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
	public class StudentProfileController : Controller
	{
		ELearningContext context = new ELearningContext();
		[HttpGet]
		public ActionResult Index()
		{
			TempData["Location"] = "Profil";
			string value = Session["CurrentMail"].ToString();
			int studentID = context.Students.Where(x => x.Email == value).Select(y => y.StudentID).FirstOrDefault();
			var studentInformations = context.Students.Where(x => x.StudentID == studentID).FirstOrDefault();
			return View(studentInformations);
		}
		[HttpPost]
		public ActionResult Index(Student student)
		{
			var value = context.Students.Find(student.StudentID);
			value.Name = student.Name;
			value.Surname = student.Surname;
			value.Email = student.Email;
			value.Password = student.Password;
			context.SaveChanges();
			return RedirectToAction("Index");
		}
		public PartialViewResult StudentInformationPartial()
		{
			string value = Session["CurrentMail"].ToString();
			int studentID = context.Students.Where(x => x.Email == value).Select(y => y.StudentID).FirstOrDefault();
			var studentInformations = context.Students.Where(x => x.StudentID == studentID).FirstOrDefault();
			ViewBag.StudentCourseCount = context.CourseRegisters.Where(x => x.StudentID == studentID).Count();
			ViewBag.StudentCommentCount = context.Comments.Where(x => x.StudentID == studentID).Count();
			ViewBag.StudentReviewScoreAverage = context.Reviews.Where(x => x.StudentID == studentID).Select(y => y.ReviewScore).Average();
			return PartialView(studentInformations);
		}
		public PartialViewResult StudentCommentList()
		{
			string value = Session["CurrentMail"].ToString();
			int studentID = context.Students.Where(x => x.Email == value).Select(y => y.StudentID).FirstOrDefault();
			ViewBag.studentNameSurname = context.Students.Where(x => x.StudentID == studentID).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
			var studentCommentList = context.Comments.Where(x => x.StudentID == studentID).ToList();
			return PartialView(studentCommentList);
		}
		public PartialViewResult StudentProfilePartial()
		{
			string value = Session["CurrentMail"].ToString();
			int studentID = context.Students.Where(x => x.Email == value).Select(y => y.StudentID).FirstOrDefault();
			var studentInformations = context.Students.Where(x => x.StudentID == studentID).FirstOrDefault();
			return PartialView(studentInformations);
		}

		public ActionResult MyCourseList()
		{
			TempData["Location"] = "Kurslarım";
			string values = Session["CurrentMail"].ToString();
			int id = context.Students.Where(x => x.Email == values).Select(y => y.StudentID).FirstOrDefault();
			var courseList = context.Processes.Where(x => x.StudentID == id).ToList();
			return View(courseList);
		}
		public ActionResult WatchCourse(int? id)
		{
			TempData["Location"] = "Kurslarım";
			ViewBag.id = id;
			ViewBag.courseName = context.Courses.Where(x => x.CourseID == id).Select(x => x.Title).FirstOrDefault();
			var values = context.CourseWatchLists.Where(x => x.CourseID == id).ToList();
			return View(values);
		}

		[HttpGet]
		public ActionResult RewievCourse(int id)
		{
			TempData["Location"] = "Değerlendirme";
			ViewBag.courseID = id;
			return View();
		}
		[HttpPost]
		public ActionResult RewievCourse(Review review)
		{
			TempData["Location"] = "Değerlendirme";
			string userEmail = Session["CurrentMail"].ToString();
			int studentId = context.Students.Where(x => x.Email == userEmail).Select(y => y.StudentID).FirstOrDefault();
			Review existingReview = context.Reviews.FirstOrDefault(r => r.StudentID == studentId && r.CourseID == review.CourseID);//Kurs var mı yok mu diye bakıyoruz


			if (existingReview != null)
			{
				existingReview.ReviewScore = review.ReviewScore;
				context.SaveChanges();
			}
			else
			{
				Review newReview = new Review
				{
					StudentID = studentId,
					CourseID = review.CourseID,
					ReviewScore = review.ReviewScore
				};

				context.Reviews.Add(newReview);
				context.SaveChanges();
			}


			TempData["ReviewSuccess"] = "Değerlendirme başarıyla kaydedildi.";

			return RedirectToAction("RewievCourse", "StudentProfile");
		}
		[HttpGet]
		public ActionResult StudentCourseBuy()
		{
			TempData["Location"] = "Kurslar";
			var values = context.Courses.ToList();
			return View(values);
		}
		[HttpPost]
		public ActionResult StudentCourseBuy(int courseID)
		{
			string values = Session["CurrentMail"].ToString();
			int studentId = context.Students.Where(x => x.Email == values).Select(y => y.StudentID).FirstOrDefault();
			bool isRegistered = context.CourseRegisters.Any(y => y.StudentID == studentId && y.CourseID == courseID);//daha kurs kayıtlı mı değil mi diye bakıyoruz

			if (isRegistered)
			{
				TempData["Message"] = "Bu kursa kayıtlısınız!";
			}
			else
			{
				CourseRegister newRegister = new CourseRegister
				{
					StudentID = studentId,
					CourseID = courseID,
					RegisterDate = DateTime.Now
				};
				context.CourseRegisters.Add(newRegister);
				context.SaveChanges();
				TempData["Message"] = "Kurs başarıyla eklendi!";
			}

			return RedirectToAction("StudentCourseBuy", "StudentProfile");
		}

	}
}