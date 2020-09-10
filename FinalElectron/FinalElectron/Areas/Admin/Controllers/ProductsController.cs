using FinalElectron.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalElectron.Models;
using System.IO;

namespace FinalElectron.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private ElectronContex db = new ElectronContex();

        // GET: Admin/Products
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


            return View(productOptions);
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.Catagories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            ViewBag.Colors = db.Colors.ToList();
            return View();
        }

        // POST: Admin/Products/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ProductOption productOption)
        {
            if (ModelState.IsValid)
            {
                // create product
                Product product = new Product();

                if (productOption.Product.HoverImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + productOption.Product.HoverImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    productOption.Product.HoverImageFile.SaveAs(imagePath);
                    product.HoverImage = imageName;
                }

                product.Name = productOption.Product.Name;
                product.SubCategoryId = productOption.Product.SubCategoryId;
                product.ModelId = productOption.Product.ModelId;
                product.Content = productOption.Product.Content;
                product.IsSpecial = productOption.Product.IsSpecial;
                product.AddedDate = productOption.AddedDate;

                db.Products.Add(product);
                db.SaveChanges();

                // for images
                foreach (HttpPostedFileBase image in productOption.Product.ImageFile)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + image.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads"), imageName);

                    image.SaveAs(imagePath);

                    ProductImage productImage = new ProductImage();
                    productImage.Name = imageName;
                    productImage.ProductId = product.Id;

                    db.ProductImages.Add(productImage);
                    db.SaveChanges();
                }

                // add prodduct options


                for (int i = 0; i < productOption.ColorIds.Length; i++)
                {
                    ProductOption productOption1 = new ProductOption();

                    productOption1.ProductId = product.Id;
                    productOption1.ColorId = productOption.ColorIds[i];
                    productOption1.Quantity = productOption.Quantities[i];
                    productOption1.Price = productOption.Prices[i];
                    productOption1.AddedDate = productOption.AddedDate;

                    db.ProductOptions.Add(productOption1);
                    db.SaveChanges();

                }


                return RedirectToAction("Create");
            }




            ViewBag.Catagories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            ViewBag.Colors = db.Colors.ToList();
            return View(productOption);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult getSubCategories(int? id)
        {
            List<SubCategory> subCategories = db.SubCategories.Where(s => s.CategoryId == id).ToList();



            string option = "<option value='0'>Choose</option>";

            foreach (var item in subCategories)
            {
                option += "<option value=" + item.Id + ">" + item.Name + "</option>";
            }

            return Content(option);
        }

        public ActionResult getModels(int? id)
        {
            List<BrandModel> brandModels= db.BrandModels.Where(s => s.BrandId == id).ToList();



            string option = "<option value='0'>Choose</option>";

            foreach (var item in brandModels)
            {
                option += "<option value=" + item.Id + ">" + item.Name + "</option>";
            }

            return Content(option);
        }

        // create new color choose with quantity and prices
        public ActionResult GetColors()
        {
            string options = "";
            foreach (Color item in db.Colors)
            {
                options += "<option value='"+item.Id+"' >"+item.Name+"</option>";
            }

            string hederChoose = "<div class='form-group col-md-3'><div class=''><label>Color</label><select class='form-control' name='ColorIds'><option value = '0' > Choose </ option > ";
            string footerChoose = "</select></div></div>";
            string addQuantityHtml = "<div class='form-group col-md-3'><label>Quantity</label><div class=''><input type='number' name='Quantities' class='form-control' value='1' /></div></div>";
            string addPriceHtml = "<div class='form-group col-md-3'><label>Price</label><div class=''><input type='text' name='Prices' class='form-control' value='0' /></div></div>";
            string addOffset = "<div class='offset-md-3'></div>";

            return Content(hederChoose + options + footerChoose + addQuantityHtml + addPriceHtml + addOffset);
        }
    }
}
