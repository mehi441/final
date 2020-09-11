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
    public class SpecificationsController : Controller
    {
        private ElectronContex db = new ElectronContex();

        // GET: Admin/Specifications
        public ActionResult Index()
        {
            var specifications = db.Specifications.Include(s => s.ProductOption).Include(s=>s.ProductOption.Product).Include(s=>s.ProductOption.Product.Model).Include(s=>s.ProductOption.Color);
            return View(specifications.ToList());
        }

        // GET: Admin/Specifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specification specification = db.Specifications.Find(id);
            if (specification == null)
            {
                return HttpNotFound();
            }
            return View(specification);
        }

        // GET: Admin/Specifications/Create
        public ActionResult Create()
        {
            ViewBag.ProductOptionId = new SelectList(db.ProductOptions, "Id", "Id");
            return View();
        }

        // POST: Admin/Specifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Content,ProductOptionId")] Specification specification)
        {
            if (ModelState.IsValid)
            {
                db.Specifications.Add(specification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductOptionId = new SelectList(db.ProductOptions, "Id", "Id", specification.ProductOptionId);
            return View(specification);
        }

        // GET: Admin/Specifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specification specification = db.Specifications.Find(id);
            if (specification == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductOptionId = new SelectList(db.ProductOptions, "Id", "Id", specification.ProductOptionId);
            return View(specification);
        }

        // POST: Admin/Specifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Content,ProductOptionId")] Specification specification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductOptionId = new SelectList(db.ProductOptions, "Id", "Id", specification.ProductOptionId);
            return View(specification);
        }

        // GET: Admin/Specifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specification specification = db.Specifications.Find(id);
            if (specification == null)
            {
                return HttpNotFound();
            }
            return View(specification);
        }

        // POST: Admin/Specifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Specification specification = db.Specifications.Find(id);
            db.Specifications.Remove(specification);
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
