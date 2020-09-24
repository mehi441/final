using FinalElectron.DAL;
using FinalElectron.Models;
using FinalElectron.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalElectron.Controllers
{
    public class FilterController : Controller
    {
        // GET: Filter
        private ElectronContex db = new ElectronContex();

        public ActionResult Index(int? id)
        {


            List<Product> proFilters = db.Products.Include("Model")
                                                          .Include("SubCategory")
                                                          .Include("SubCategory.Category")
                                                          .Include("ProductImages")
                                                          .Include("ProductOptions")
                                                          .Include("ProductOptions.Color")
                                                          .Include("Reviews")
                                                          .Where(p => p.SubCategoryId==id)
                                                          .ToList();
            // brands name and count
            List<KeyValuePair<string, int>> brandAndCount = new List<KeyValuePair<string, int>>();

            List<Brand> brands = db.Brands.ToList();

            foreach (var item in brands)
            {
                brandAndCount.Add(new KeyValuePair<string, int>(item.Name, db.ProductOptions.Where(p=>p.Product.Model.Brand.Name==item.Name).ToList().Count));
            }

            int stockCount = db.ProductOptions.Where(p => p.Quantity > 0).ToList().Count;
            int outOfStockCount = db.ProductOptions.Where(p => p.Quantity == 0).ToList().Count;
            // is stock and out of stock count
            KeyValuePair<int, int> stockAndOutSrock = new KeyValuePair<int, int>( stockCount , outOfStockCount);


            // brands list
            

            VmFilter vmFilter = new VmFilter();
            vmFilter.BrandAndCounts = brandAndCount;
            vmFilter.ProFilters = proFilters;
            vmFilter.StockAndOutSrock = stockAndOutSrock;
            vmFilter.Brands = brands;


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
            return View(vmFilter);
        }

        public JsonResult GetData(int MinPrc, int MaxPrc , int[] BrandId, string IsStock , int SortId, int ShowCnt )
        {
            List<ProductOption> productOptions = new List<ProductOption>();

            if (BrandId != null)
            {
                foreach (var item in BrandId)
                {
                    productOptions.AddRange(db.ProductOptions.Where(p=>p.Product.Model.BrandId==item)
                                                    .Include("Color")
                                                    .Include("Product")
                                                    .Include("Product.Reviews")
                                                    .Include("Product.SubCategory")
                                                    .Include("Product.SubCategory.Category")
                                                    .Include("Product.Model")
                                                    .Include("Product.Model.Brand")
                                                    .Include("Product.ProductImages")
                                                     );
                }
            }
            else
            {
                productOptions = db.ProductOptions.Include("Color")
                                                  .Include("Product")
                                                  .Include("Product.Reviews")
                                                  .Include("Product.SubCategory")
                                                  .Include("Product.SubCategory.Category")
                                                  .Include("Product.Model")
                                                  .Include("Product.Model.Brand")
                                                  .Include("Product.ProductImages")
                                                  .ToList();
            }

            if (SortId == 0)
            {
                productOptions = productOptions.OrderByDescending(p => p.Id).ToList();
            }
            else if (SortId == 1)
            {
                productOptions = productOptions.OrderBy(b => b.Product.Model.Brand.Name).ThenBy(m => m.Product.Model.Name).ThenBy(c => c.Color.Name).ToList();
            }
            else if (SortId == 2)
            {
                productOptions = productOptions.OrderByDescending(b => b.Product.Model.Brand.Name).ThenByDescending (m => m.Product.Model.Name).ThenByDescending(c => c.Color.Name).ToList();
            }
            else if (SortId == 3)
            {
                productOptions = productOptions.OrderBy(p => p.Price).ThenBy(b => b.Product.Model.Brand.Name).ToList();
            }
            else if (SortId == 4)
            {
                productOptions = productOptions.OrderByDescending(p => p.Price).ThenByDescending(b => b.Product.Model.Brand.Name).ToList();
            }
            else if (SortId == 5)
            {
                productOptions = productOptions.OrderByDescending(b => b.Product.Reviews.Count==0?  0 : b.Product.Reviews.Sum(r => r.Star) / b.Product.Reviews.Count).ThenByDescending(m => m.Product.Model.Brand.Name).ThenByDescending(c => c.Color.Name).ToList();
            }
            else if (SortId == 6)
            {
                productOptions = productOptions.OrderBy(b => b.Product.Reviews.Count == 0 ? 0 : b.Product.Reviews.Sum(r => r.Star) / b.Product.Reviews.Count).ThenBy(m => m.Product.Model.Brand.Name).ThenBy(c => c.Color.Name).ToList();
            }
            else if (SortId == 7)
            {
                productOptions = productOptions.OrderBy(p => p.Product.Model.Name).ThenBy(b => b.Product.Model.Brand.Name).ToList();
            }
            else if (SortId == 8)
            {
                productOptions = productOptions.OrderByDescending(p => p.Product.Model.Name).ThenByDescending(b => b.Product.Model.Brand.Name).ToList();
            }

            var products = productOptions.Where(p => (p.Price >= MinPrc) &&
                                                     (p.Price <= MaxPrc) &&
                                                     (IsStock == null ? true : (IsStock == "yes" ? p.Quantity > 0 : p.Quantity == 0))
                                                    ).Select(p => new
                                                    {
                                                        p.Id,
                                                        ColorName = p.Color.Name,
                                                        Img = p.Product.ProductImages.FirstOrDefault().Name,
                                                        HoverImg= p.Product.HoverImage,
                                                        p.Quantity,
                                                        ProName = p.Product.Name,
                                                        ModelName = p.Product.Model.Name,
                                                        BrandName = p.Product.Model.Brand.Name,
                                                        Price= p.Price.ToString("#.00"),
                                                        OldPrice =p.OldPrice.ToString("#.00"),
                                                        StarCount= (p.Product.Reviews.Count==0? 0 : p.Product.Reviews.Sum(r => r.Star) / p.Product.Reviews.Count)
                                                    }).ToList();


            return Json(products, JsonRequestBehavior.AllowGet);
        }
    }
}