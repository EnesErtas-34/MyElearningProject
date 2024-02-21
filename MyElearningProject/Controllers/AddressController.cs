using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class AddressController : Controller
    {
        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            var values = context.Addresses.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddAddress()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAddress(Address address)
        {
            context.Addresses.Add(address);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAddress(int id)
        {
            var values = context.Addresses.Find(id);
            context.Addresses.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAddress(int id)
        {
            var values = context.Addresses.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateAddress(Address address)
        {
            var values = context.Addresses.Find(address.AddressID);
            values.AddressOfice = address.AddressOfice;
            values.Phone = address.Phone;
            values.Email = address.Email;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}