using FinalElectron.DAL;
using FinalElectron.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace FinalElectron.Controllers
{
    public class RegisterController : Controller
    {
        private ElectronContex db = new ElectronContex();

        // GET: Register
        public ActionResult Index()
        {
            



            ViewBag.Categories = db.Categories.Include("SubCategories").ToList();
            ViewBag.LatestProS = db.Products.OrderByDescending(p => p.Id).Take(21).ToList();
            ViewBag.Testimonials = db.Testimonials.OrderByDescending(p => p.Id).Take(6).ToList();
            return View();
        }
    
        [HttpPost]
        public ActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                if (user.Password!=user.RePassword)
                {
                    ModelState.AddModelError("Password", "Passwords are different");


                    ViewBag.Categories = db.Categories.Include("SubCategories").ToList();
                    ViewBag.LatestProS = db.Products.OrderByDescending(p => p.Id).Take(21).ToList();
                    ViewBag.Testimonials = db.Testimonials.OrderByDescending(p => p.Id).Take(6).ToList();
                    return View(user);
                }
                if (user.IsAgree==false)
                {


                    ModelState.AddModelError("", " Warning: You must agree to the Privacy Policy! " );

                    ViewBag.Categories = db.Categories.Include("SubCategories").ToList();
                    ViewBag.LatestProS = db.Products.OrderByDescending(p => p.Id).Take(21).ToList();
                    ViewBag.Testimonials = db.Testimonials.OrderByDescending(p => p.Id).Take(6).ToList();
                    return View(user);
                }

                user.Password = Crypto.HashPassword(user.Password);
                if (user.Newsletter=="yes")
                {
                    user.IsNewsletter = true;
                }
                else
                {
                    user.IsNewsletter = false;
                }
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index", "Login");
              
            }



            ViewBag.Categories = db.Categories.Include("SubCategories").ToList();
            ViewBag.LatestProS = db.Products.OrderByDescending(p => p.Id).Take(21).ToList();
            ViewBag.Testimonials = db.Testimonials.OrderByDescending(p => p.Id).Take(6).ToList();
            return View();
        }



    }
}