using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class DefaultFeatureController : Controller
    {
        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            TempData["Location"] = "Öne Çıkarılan";
            var values = context.DefaultFeatures.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddDefaultFeature()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddDefaultFeature(DefaultFeature defaultFeature)
        {
            context.DefaultFeatures.Add(defaultFeature);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteDefaultFeature(int id)
        {
            var value = context.DefaultFeatures.Find(id);
            context.DefaultFeatures.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateDefaultFeature(int id)
        {

            var value = context.DefaultFeatures.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateDefaultFeature(DefaultFeature defaultFeature)
        {
            var value = context.DefaultFeatures.Find(defaultFeature.DefaultFeatureID);
            value.Title = defaultFeature.Title;
            value.Title2 = defaultFeature.Title2;
            value.Description = defaultFeature.Description;
            value.Description2 = defaultFeature.Description2;
            value.ImageURL = defaultFeature.ImageURL;
            value.ImageURL2 = defaultFeature.ImageURL2;
            context.SaveChanges();
            return RedirectToActionPermanent("Index");

        }
    }
}