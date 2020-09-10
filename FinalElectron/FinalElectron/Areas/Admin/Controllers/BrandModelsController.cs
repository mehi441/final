using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalElectron.DAL;
using FinalElectron.Models;

namespace FinalElectron.Areas.Admin.Controllers
{
    public class BrandModelsController : Controller
    {
        private ElectronContex db = new ElectronContex();

        // GET: Admin/BrandModels
        public ActionResult Index()
        {
            var brandModels = db.BrandModels.Include(b => b.Brand);
            return View(brandModels.ToList());
        }


        // GET: Admin/BrandModels/Create
        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name");
            return View();
        }

        // POST: Admin/BrandModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,BrandId")] BrandModel brandModel)
        {
            if (ModelState.IsValid)
            {
                db.BrandModels.Add(brandModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name", brandModel.BrandId);
            return View(brandModel);
        }

        // GET: Admin/BrandModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrandModel brandModel = db.BrandModels.Find(id);
            if (brandModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name", brandModel.BrandId);
            return View(brandModel);
        }

        // POST: Admin/BrandModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,BrandId")] BrandModel brandModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brandModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name", brandModel.BrandId);
            return View(brandModel);
        }

        // GET: Admin/BrandModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrandModel brandModel = db.BrandModels.Find(id);
            if (brandModel == null)
            {
                return HttpNotFound();
            }
            return View(brandModel);
        }

        // POST: Admin/BrandModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BrandModel brandModel = db.BrandModels.Find(id);
            db.BrandModels.Remove(brandModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
