using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class AboutFeatureController : Controller
    {
        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            var values = context.AboutFeatures.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddAboutFeature()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAboutFeature(AboutFeature aboutFeature)
        {
            context.AboutFeatures.Add(aboutFeature);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAboutFeature(int id)
        {
            var values = context.AboutFeatures.Find(id);
            context.AboutFeatures.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAboutFeature(int id)
        {
            var values = context.AboutFeatures.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateAboutFeature(AboutFeature aboutFeature)
        {
            var values = context.AboutFeatures.Find(aboutFeature.AboutFeatureID);
            values.icon = aboutFeature.icon;
            values.Title = aboutFeature.Title;
            values.Description = aboutFeature.Description;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}