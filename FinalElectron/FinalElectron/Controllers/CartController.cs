using FinalElectron.DAL;
using FinalElectron.Models;
using FinalElectron.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalElectron.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
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
                if (item.Value>0 && item.Value<10)
                {
                    cartPrice += (price * item.Value );
                }
                else if (item.Value >= 10 && item.Value < 20)
                {
                    cartPrice += (price * 95 / 100 *item.Value );
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
            KeyValuePair<int, decimal> cartCountPrice = new KeyValuePair<int, decimal>(cartCount,cartPrice);
            ViewBag.CartCountPrice = cartCountPrice;
            #endregion

            #region Wish list
            if (Session["User"] != null)
            {
                int userIdSession = (int)Session["UserId"];
                ViewBag.WishListCount = db.Wishlists.Where(w=> w.UserId==userIdSession).ToList().Count ;
            }
            else
            {
                ViewBag.WishListCount = 0;
            }
            #endregion


            VmCart vmCart = new VmCart();
            vmCart.ProductOptions = productOptions;
            vmCart.List = list;

            ViewBag.Categories = db.Categories.Include("SubCategories").ToList();
            ViewBag.LatestProS = db.Products.OrderByDescending(p => p.Id).Take(21).ToList();
            ViewBag.Testimonials = db.Testimonials.OrderByDescending(p => p.Id).Take(6).ToList();
            return View(vmCart);
        }

        public JsonResult AddToCart(int? id, decimal? count)
        {
            string response = "";
            if (id != null && count != null)
            {
                if (Request.Cookies["Cart"] != null)
                {
                    string oldList = Request.Cookies["Cart"].Value;
                    HttpCookie cookie = new HttpCookie("Cart");
                    cookie.Value = oldList;
                    List<string> cartList = oldList.Split(',').ToList();
                    cartList.RemoveAt(cartList.Count - 1);



                    string cartElement = cartList.FirstOrDefault(c => Convert.ToInt32(c.Split('-')[0]) == id);


                    if (cartElement == null)
                    {
                        cookie.Value += id + "-" + count + ",";
                        Request.Cookies["Cart"].Expires = DateTime.Now.AddYears(1);
                        Response.Cookies.Add(cookie);
                        response = "success-true";
                    }
                    else
                    {
                        cartList.Remove(cartElement);

                        if (cartList.Count() > 0)
                        {
                            cookie.Value = string.Join(",", cartList) + ",";
                            cookie.Value += id + "-" + count + ",";
                        }
                        else
                        {
                            cookie.Value = id + "-" + count + ",";
                        }

                        Request.Cookies["Cart"].Expires = DateTime.Now.AddYears(1);
                        Response.Cookies.Add(cookie);
                        response = "success-false";
                    }


                }
                else
                {
                    HttpCookie cookie = new HttpCookie("Cart");

                    cookie.Expires = DateTime.Now.AddYears(1);
                    cookie.Value += id + "-" + count + ",";
                    Response.Cookies.Add(cookie);
                    response = "success-true";
                }
            }
            else
            {
                response = "error";
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemoveFromCart(int? id)
        {
            string response = "";
            if (id != null)
            {
                string oldList = Request.Cookies["Cart"].Value;
                HttpCookie cookie = new HttpCookie("Cart");
                List<string> cartList = oldList.Split(',').ToList();
                cartList.RemoveAt(cartList.Count - 1);

                string cartElement = cartList.FirstOrDefault(c => Convert.ToInt32(c.Split('-')[0]) == id);
                if (cartElement != null)
                {
                    cartList.Remove(cartElement);

                    if (cartList.Count() > 0)
                    {
                        cookie.Value = string.Join(",", cartList) + ",";
                    }
                    else
                    {
                        cookie.Value = "";
                    }

                    Request.Cookies["Cart"].Expires = DateTime.Now.AddYears(1);
                    Response.Cookies.Add(cookie);
                    response = "success-true";
                }
            }
            else
            {
                response = "error";
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }


        // add wish to user
        public ActionResult AddWishToUser(int? id)
        {
            string response = "";

            if (Session["User"] == null)
            {
                response = "success-false";
                return Content(response);
            }

            if (id!=null)
            {
                int userIdSession = (int)Session["UserId"];
                int proId = (int)id;
                 
                if (db.Wishlists.FirstOrDefault(w => w.UserId == userIdSession && w.ProductOptionId ==proId ) == null)
                {
                    Wishlist wishlist = new Wishlist();
                    wishlist.ProductOptionId = proId;
                    wishlist.UserId = userIdSession;

                    db.Wishlists.Add(wishlist);
                    db.SaveChanges();
                    response = "success-true";
                    return Content(response);
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

            return Content(response);
        }










      



    }
}