﻿using FinalElectron.DAL;
using FinalElectron.Models;
using FinalElectron.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace FinalElectron.Controllers
{
    public class LoginController : Controller
    {
        private ElectronContex db = new ElectronContex();

        // GET: Login
        public ActionResult Index()
        {


            #region Cart list

            // for cookie cart for Cart table
            List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>();
            HttpCookie cookieCart = Request.Cookies["Cart"];
            List<string> CartList = new List<string>();
            if (cookieCart != null)
            {
                CartList = cookieCart.Value.Split(',').ToList();
                CartList.RemoveAt(CartList.Count - 1);

                foreach (var item in CartList)
                {
                    list.Add(new KeyValuePair<int, int>(Convert.ToInt32(item.Split('-')[0]), Convert.ToInt32(item.Split('-')[1])));
                }
            }
            // end for cookie cart for Cart table


            int cartCount = 0;
            decimal cartPrice = 0;
            foreach (var item in list)
            {
                cartCount += item.Value;

                decimal price = db.ProductOptions.Find(item.Key).Price;
                if (item.Value > 0 && item.Value < 10)
                {
                    cartPrice += (price * item.Value);
                }
                else if (item.Value >= 10 && item.Value < 20)
                {
                    cartPrice += (price * 95 / 100 * item.Value);
                }
                else if (item.Value >= 20 && item.Value < 30)
                {
                    cartPrice += (price * 88 / 100 * item.Value);
                }
                else if (item.Value >= 30)
                {
                    cartPrice += (price * 80 / 100 * item.Value);
                }
            }
            KeyValuePair<int, decimal> cartCountPrice = new KeyValuePair<int, decimal>(cartCount, cartPrice);
            ViewBag.CartCountPrice = cartCountPrice;
            #endregion
            #region Wish list
            if (Session["User"] != null)
            {
                int userIdSession = (int)Session["UserId"];
                ViewBag.WishListCount = db.Wishlists.Where(w => w.UserId == userIdSession).ToList().Count;
            }
            else
            {
                ViewBag.WishListCount = 0;
            }
            #endregion
            #region Compare list
            HttpCookie cookie = Request.Cookies["CompareList"];
            if (cookie != null)
            {
                List<string> CompList = cookie.Value.Split(',').ToList();

                CompList.RemoveAt(CompList.Count - 1);

                ViewBag.CompareListCount = CompList.Count;
            }
            else
            {
                ViewBag.CompareListCount = 0;
            }
            #endregion


            ViewBag.Categories = db.Categories.Include("SubCategories").ToList();
            ViewBag.LatestProS = db.Products.OrderByDescending(p => p.Id).Take(21).ToList();
            ViewBag.Testimonials = db.Testimonials.OrderByDescending(p => p.Id).Take(6).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login login)
        {

            if (ModelState.IsValid)
            {
                User user = db.Users.FirstOrDefault(u => u.Email == login.Email);

                if (user!=null)
                {
                    if (Crypto.VerifyHashedPassword(user.Password, login.Password))
                    {
                        Session["User"] = true;
                        Session["UserId"] = user.Id;

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Wrong password or Email");


                        ViewBag.Categories = db.Categories.Include("SubCategories").ToList();
                        ViewBag.LatestProS = db.Products.OrderByDescending(p => p.Id).Take(21).ToList();
                        ViewBag.Testimonials = db.Testimonials.OrderByDescending(p => p.Id).Take(6).ToList();
                        return View(login);
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "Wrong Email");


                    ViewBag.Categories = db.Categories.Include("SubCategories").ToList();
                    ViewBag.LatestProS = db.Products.OrderByDescending(p => p.Id).Take(21).ToList();
                    ViewBag.Testimonials = db.Testimonials.OrderByDescending(p => p.Id).Take(6).ToList();
                    return View(login);
                }
            }

            ViewBag.Categories = db.Categories.Include("SubCategories").ToList();
            ViewBag.LatestProS = db.Products.OrderByDescending(p => p.Id).Take(21).ToList();
            ViewBag.Testimonials = db.Testimonials.OrderByDescending(p => p.Id).Take(6).ToList();
            return View(login);
        }


        public ActionResult Logout()
        {
            Session["User"] = null;
            Session["UserId"] = null;

            return RedirectToAction("Index", "Home");
        }
    }
}