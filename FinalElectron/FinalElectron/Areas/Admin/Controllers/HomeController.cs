using FinalElectron.Areas.Admin.Filters;
using FinalElectron.DAL;
using FinalElectron.Models;
using FinalElectron.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace FinalElectron.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        private ElectronContex db = new ElectronContex();

        [logout]
        public ActionResult Index()
        {
            return View();
        }

        [logout]
        public ActionResult HotDeal()
        {
            return View(db.HotDeals.Include("ProductOption")
                                   .Include("ProductOption.Color")
                                   .Include("ProductOption.Product")
                                   .Include("ProductOption.Product.Model")
                                   .Include("ProductOption.Product.Model.Brand")
                                   .ToList());
        }

        // create
        [logout]
        public ActionResult CreateHot()
        {
            ViewBag.ProductOptions = db.ProductOptions.Include("Product")
                                                      .Include("Color")
                                                      .Include("Product.Model")
                                                      .Include("Product.Model.Brand")
                                                      .ToList();
            return View();
        }

        [logout]
        [HttpPost]
        public ActionResult CreateHot(HotDeal hotDeal)
        {
            if (ModelState.IsValid)
            {
                if (hotDeal.ProductOptionId==0)
                {
                    ViewBag.ProductOptions = db.ProductOptions.Include("Product")
                                                      .Include("Color")
                                                      .Include("Product.Model")
                                                      .Include("Product.Model.Brand")
                                                      .ToList();
                    ModelState.AddModelError("", "please select product");
                    return View();
                }
                else
                {
                    hotDeal.AddedDate = DateTime.Now;

                    hotDeal.EndDate = hotDeal.EndDateForm;

                    int hours = hotDeal.EndTime.Hour;
                    hotDeal.EndDate = hotDeal.EndDate.AddHours(hours);
                    int minutes = hotDeal.EndTime.Minute;
                    hotDeal.EndDate= hotDeal.EndDate.AddMinutes(minutes);


                    db.HotDeals.Add(hotDeal);
                    db.SaveChanges();

                    return RedirectToAction("HotDeal");
                }


            }

            ViewBag.ProductOptions = db.ProductOptions.Include("Product")
                                                      .Include("Product.Model")
                                                      .Include("Product.Model.Brand")
                                                      .Include("Color")
                                                      .ToList();
            return View();
        }

        // delete hot deal
        [logout]
        public ActionResult DeleteHot(int? id)
        {
            HotDeal hotDeal = db.HotDeals.Find(id);
            if (hotDeal == null)
            {
                return HttpNotFound();
            }
            db.HotDeals.Remove(hotDeal);
            db.SaveChanges();

            return RedirectToAction("HotDeal");
        }




        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginAdmin login)
        {
            if (ModelState.IsValid)
            {
                Models.Admin admin = db.Admins.FirstOrDefault(a => a.Username == login.Username);

                if (admin != null)
                {
                    if (Crypto.VerifyHashedPassword(admin.Password, login.Password) == true)
                    {
                        Session["Admin"] = admin;
                        Session["AdminId"] = admin.Id;

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Wrong password or Email");
                        return View(login);
                    }
                }
                else
                {
                    ModelState.AddModelError("Username", "Wrong Username");
                    return View(login);
                }
            }
            return View(login);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login"); ;
        }
    }
}