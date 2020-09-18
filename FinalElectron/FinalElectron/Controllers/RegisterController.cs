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
            if (Session["User"]!=null)
            {
                return RedirectToAction("Index", "Home");
            }

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

                if (user.Newsletter == "yes")
                {
                    user.IsNewsletter = true;

                    Newsletter newsletter = new Newsletter();
                    newsletter.Email = user.Email;
                    newsletter.AddedDate = DateTime.Now;

                    db.Newsletters.Add(newsletter);
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "Login");
              
            }



            ViewBag.Categories = db.Categories.Include("SubCategories").ToList();
            ViewBag.LatestProS = db.Products.OrderByDescending(p => p.Id).Take(21).ToList();
            ViewBag.Testimonials = db.Testimonials.OrderByDescending(p => p.Id).Take(6).ToList();
            return View();
        }



    }
}