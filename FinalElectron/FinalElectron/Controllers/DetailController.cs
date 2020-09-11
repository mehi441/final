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



            ViewBag.Categories = db.Categories.Include("SubCategories").ToList();
            ViewBag.LatestProS = db.Products.OrderByDescending(p => p.Id).Take(21).ToList();
            ViewBag.Testimonials = db.Testimonials.OrderByDescending(p => p.Id).Take(6).ToList();
            return View(vmDetail);
        }

        //[HttpPost]
        //public ActionResult writeReview(string name, string content, string stars , int id)
        //{

        //    Review review = new Review();

        //    review.Name = name;
        //    review.Content = content;
        //    review.ProductId = id;

        //    return Content("Index");
        //}

        [HttpPost]
        public ActionResult writeReview( string Name, string Content, string Star, int ProductId)
        {


            Review review1 = new Review();

            review1.Name = Name;
            review1.Content = Content;
            review1.ProductId = ProductId;
            review1.AddedDate = DateTime.Now;



            if (Star=="1")
            {
                review1.Star = 1;
            }
            else if (Star == "2")
            {
                review1.Star = 2;
            }
            else if (Star == "3")
            {
                review1.Star = 3;
            }
            else if (Star == "4")
            {
                review1.Star = 4;
            }
            else if(Star == "5")
            {
                review1.Star = 5;
            }

            db.Reviews.Add(review1);
            db.SaveChanges();

            return View("Index");
        }



    }
}