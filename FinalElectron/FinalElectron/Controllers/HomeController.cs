using FinalElectron.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalElectron.ViewModels;
using FinalElectron.Models;

namespace FinalElectron.Controllers
{
    public class HomeController : Controller
    {
        private ElectronContex db = new ElectronContex();

        public ActionResult Index()
        {
            List<Product> productsCategories = db.Products.Include("Model")
                                               .Include("ProductImages")
                                               .Include("ProductOptions")
                                               .Include("ProductOptions.Color")
                                               .Include("Reviews")
                                               .ToList();

            List<Product> productsForSpecial = db.Products.Include("Model")
                                               .Include("ProductImages")
                                               .Include("ProductOptions")
                                               .Include("ProductOptions.Color")
                                               .Where(p=>p.IsSpecial==true)
                                               .ToList();

            List<Product> productsLatest = db.Products
                                               .Include("Model")
                                               .Include("ProductImages")
                                               .Include("ProductOptions")
                                               .Include("ProductOptions.Color")
                                               .OrderByDescending(o => o.Id)
                                               .ToList();




            VmHome vmHome = new VmHome();
            vmHome.ProductsForCategories = productsCategories;
            vmHome.ProductsSpecial = productsForSpecial;
            vmHome.ProductsLatest = productsLatest;




            ViewBag.Categories = db.Categories.Include("SubCategories").ToList();
            ViewBag.LatestProS = db.Products.OrderByDescending(p => p.Id).Take(21).ToList();
            ViewBag.Testimonials = db.Testimonials.OrderByDescending(p => p.Id).Take(6).ToList();
            return View(vmHome);
        }

       
    }
}