﻿using FinalElectron.DAL;
using FinalElectron.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalElectron.Controllers
{
    public class SpecialController : Controller
    {
        // GET: Special
        private ElectronContex db = new ElectronContex();

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

            List<Product> specialPros = db.Products.Include("Model")
                                             .Include("ProductImages")
                                             .Include("ProductOptions")
                                             .Include("ProductOptions.Color")
                                             .Include("Reviews")
                                             .Where(p => p.IsSpecial == true)
                                             .ToList();

            ViewBag.Categories = db.Categories.Include("SubCategories").ToList();
            ViewBag.LatestProS = db.Products.OrderByDescending(p => p.Id).Take(21).ToList();
            ViewBag.Testimonials = db.Testimonials.OrderByDescending(p => p.Id).Take(6).ToList();
            return View(specialPros);
        }
    }
}