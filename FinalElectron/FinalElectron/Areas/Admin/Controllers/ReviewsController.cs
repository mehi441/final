using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalElectron.Areas.Admin.Filters;
using FinalElectron.DAL;
using FinalElectron.Models;

namespace FinalElectron.Areas.Admin.Controllers
{
    [logout]

    public class ReviewsController : Controller
    {
        private ElectronContex db = new ElectronContex();

        // GET: Admin/Reviews
        public ActionResult Index()
        {
            var reviews = db.Reviews.Include(r => r.Product);
            return View(reviews.ToList());
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
