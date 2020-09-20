using FinalElectron.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalElectron.Models;
using FinalElectron.ViewModels;

namespace FinalElectron.Controllers
{
    public class DetailController : Controller
    {
        private ElectronContex db = new ElectronContex();

        // GET: Detail
        public ActionResult Index(int? id)
        {
            ProductOption productOption = db.ProductOptions.Find(id);
            Product product = db.Products.Include("ProductImages")
                                         .Include("SubCategory")
                                         .Include("SubCategory.Category")
                                         .Include("Model")
                                         .Include("Model.Brand")
                                         .Include("Reviews")
                                         .Include("Descriptions")
                                         .Include("ProductOptions")
                                         .FirstOrDefault(p=> p.Id==productOption.ProductId);


            List<Specification> specifications = db.Specifications.Where(s => s.ProductOptionId == id).ToList();

            Color color = db.Colors.FirstOrDefault(c=> c.Id==productOption.ColorId);

            ProductImage productImage = db.ProductImages.FirstOrDefault(i=> i.ProductId==product.Id);

            List<ProductOption> productOptions = db.ProductOptions.Include("Color").Where(p => p.ProductId == product.Id).ToList();

            // for pro  code 00000078 
            string code = "";
            int steps = 8 - id.ToString().Length;
            for (int i = 0; i < steps; i++)
            {
                code = code + "0";
            }
            code = code + id.ToString();

            VmDetail vmDetail = new VmDetail();

            vmDetail.ProOption = productOption;
            vmDetail.Product = product;
            vmDetail.Color = color;
            vmDetail.ProductImage = productImage;
            vmDetail.Code = code;
            vmDetail.ProductOptions = productOptions;
            vmDetail.Specifications = specifications;

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
            return View(vmDetail);
        }


        [HttpPost]
        public ActionResult writeReview( Review review )
        {
            if (review.Name==null|| review.Name.Length==0 || review.Name.Length >70)
            {
                 return Content("error-name");
            }
            if (review.Content == null || review.Content.Length < 10 || review.Content.Length > 500)
            {
                return Content("error-content");
            }
            if (review.Star == 0)
            {
                return Content("error-star");
            }
            if (ModelState.IsValid)
            {
                review.AddedDate = DateTime.Now;
                db.Reviews.Add(review);
                db.SaveChanges();
                return Content("sucs");
            }
            return Content("error");
        }



    }
}