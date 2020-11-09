using FinalElectron.DAL;
using FinalElectron.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalElectron.Areas.Admin.Controllers
{
    public class AdSliderController : Controller
    {
        // GET: Admin/AdSlider
        private ElectronContex db = new ElectronContex();

        public ActionResult Index()
        {
            return View(db.AdSlides.ToList());
        }


        // GET: Admin/AdSlider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdSlider/Create
        [HttpPost]
        public ActionResult Create(AdSlide adSlide)
        {
            if (ModelState.IsValid)
            {
                if (adSlide.ImageFile == null)
                {
                    ModelState.AddModelError("ImageFile", "image is requred");
                    return View(adSlide);
                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + adSlide.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    adSlide.ImageFile.SaveAs(imagePath);
                    adSlide.Image = imageName;
                }

                adSlide.AddedDate = DateTime.Now;

                adSlide.EndDate = adSlide.EndDateForm;


                int hours = adSlide.EndTime.Hour;
                adSlide.EndDate = adSlide.EndDate.AddHours(hours);
                int minutes = adSlide.EndTime.Minute;
                adSlide.EndDate = adSlide.EndDate.AddMinutes(minutes);

                db.AdSlides.Add(adSlide);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(adSlide);
        }


        // GET: Admin/AdSlider/Delete/5
        public ActionResult Delete(int id)
        {
            AdSlide adSlide = db.AdSlides.Find(id);
            db.AdSlides.Remove(adSlide);
            db.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}
