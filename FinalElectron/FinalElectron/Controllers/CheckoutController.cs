using Antlr.Runtime.Misc;
using FinalElectron.DAL;
using FinalElectron.Models;
using FinalElectron.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace FinalElectron.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout

        private ElectronContex db = new ElectronContex();

        public ActionResult Index()
        {
            List<ProductOption> productOptions = db.ProductOptions.Include("Color")
                                                      .Include("Product")
                                                      .Include("Product.SubCategory")
                                                      .Include("Product.SubCategory.Category")
                                                      .Include("Product.Model")
                                                      .Include("Product.Model.Brand")
                                                      .Include("Product.ProductImages")
                                                      .ToList();



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

            if (Session["User"]!=null)
            {
                int userIdSes = (int)Session["UserId"];
                ViewBag.UserAddresses = db.UserAddresses.Where(u => u.UserId == userIdSes).ToList();
            }

            VmCart vmCart = new VmCart();
            vmCart.ProductOptions = productOptions;
            vmCart.List = list;

            ViewBag.Categories = db.Categories.Include("SubCategories").ToList();
            ViewBag.LatestProS = db.Products.OrderByDescending(p => p.Id).Take(21).ToList();
            ViewBag.Testimonials = db.Testimonials.OrderByDescending(p => p.Id).Take(6).ToList();
            return View(vmCart);
        }


        [HttpPost]
        public ActionResult AddAddressToOrder(Order order)
        {
            if (order.AddressId!=0)
            {
                order.IsReady = false;
                order.AddedDate = DateTime.Now;

                db.Orders.Add(order);
                db.SaveChanges();
                string orderId = order.Id.ToString();
                return Content(orderId);
            }
            return Content("error");
        }
         

        [HttpPost]
        public ActionResult AddShipToOrder(Order order)
        {

            Order order1 = db.Orders.Find(order.Id);
            if (order1 != null)
            {
                order1.Note = order.Note;
                order1.AddedDate = DateTime.Now;
                if (order.IsShipString=="yes")
                {
                    order1.IsFreeShipping = false;
                    order1.ShippingPrice = 13;
                }
                else
                {
                    order1.IsFreeShipping = true;
                    order1.ShippingPrice = 0;
                }

                db.Entry(order1).State = EntityState.Modified;
                db.SaveChanges();

                return Content("Sucses");
            }
            return Content("error");
        }


        // add pay pethod to order
        [HttpPost]
        public ActionResult AddPayToOrder(Order order)
        {
            Order order1 = db.Orders.Find(order.Id);

            if (order1 != null)
            {
                if (order.IsShipString == "yes")
                {
                    order1.PeymentMethod = false;
                }
                else
                {
                    order1.PeymentMethod = true;
                }
                order1.AddedDate = DateTime.Now;

                db.Entry(order1).State = EntityState.Modified;
                db.SaveChanges();

                return Content("Sucses");
            }
            return Content("error");
        }


        // add products to order 
        public JsonResult AddItemOToOrder(int? id)
        {
            string response = "";
            if (id != null)
            {

                if (db.Orders.Find(id)!=null)
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

                    foreach (var item in list)
                    {
                        OrderItem orderItem = new OrderItem();
                        orderItem.ProductOptionId = item.Key;
                        orderItem.OrderId = (int)id;
                        orderItem.Quantity = item.Value;

                        if (item.Value > 0 && item.Value < 10)
                        {
                            orderItem.Price = db.ProductOptions.Find(item.Key).Price;
                        }
                        else if (item.Value >= 10 && item.Value < 20)
                        {
                            orderItem.Price = db.ProductOptions.Find(item.Key).Price*95/100;
                        }
                        else if (item.Value >= 20 && item.Value < 30)
                        {
                            orderItem.Price = db.ProductOptions.Find(item.Key).Price*88/100;
                        }
                        else if (item.Value >= 30)
                        {
                            orderItem.Price = db.ProductOptions.Find(item.Key).Price*80/100;
                        }

                        db.OrderItems.Add(orderItem);
                        db.SaveChanges();

                    }


                    Order order = db.Orders.Find(id);
                    order.IsReady = true;
                    db.Entry(order).State = EntityState.Modified;
                    db.SaveChanges();


                    HttpCookie cookie = new HttpCookie("Cart");

                    cookie.Expires = DateTime.Now.AddYears(1);
                    cookie.Value += "";
                    Response.Cookies.Add(cookie);
                    response = "sucses";

                }
                else
                {
                    response = "error";
                }

            }
            else
            {
                response = "error";
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        //  check ligin
        [HttpPost]
        public ActionResult CheckLogin(Login login)
        {
            if (ModelState.IsValid)
            {
                User user = db.Users.FirstOrDefault(u => u.Email == login.Email);

                if (user != null)
                {
                    if (Crypto.VerifyHashedPassword(user.Password, login.Password))
                    {
                        Session["User"] = true;
                        Session["UserId"] = user.Id;

                        return Content("Sucses");

                    }
                    else
                    {
                        return Content("error-password");
                    }
                }
                else
                {
                    return Content("error-email");
                }
            }

            return Content("error");
        }



    }
}