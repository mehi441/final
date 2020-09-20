using FinalElectron.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalElectron.Controllers
{
    public class CompareController : Controller
    {
        // GET: Compare
        private ElectronContex db = new ElectronContex();

        public ActionResult Index()
        {

            ViewBag.Categories = db.Categories.Include("SubCategories").ToList();
            ViewBag.LatestProS = db.Products.OrderByDescending(p => p.Id).Take(21).ToList();
            ViewBag.Testimonials = db.Testimonials.OrderByDescending(p => p.Id).Take(6).ToList();
            return View();
        }


        public JsonResult AddCompare(int? id)
        {
            string response = "";
            if (id != null)
            {
                if (Request.Cookies["CompareList"] != null)
                {
                    string oldList = Request.Cookies["CompareList"].Value;
                    HttpCookie cookie = new HttpCookie("CompareList");
                    cookie.Value = oldList;

                    if (!oldList.Contains(id.ToString()))
                    {
                        cookie.Value += id + ",";
                        Request.Cookies["CompareList"].Expires = DateTime.Now.AddYears(1);
                        Response.Cookies.Add(cookie);
                        response = "success-true";
                    }
                    else
                    {
                        response = "success-false";
                    }

                }
                else
                {
                    HttpCookie cookie = new HttpCookie("CompareList");

                    cookie.Expires = DateTime.Now.AddYears(1);
                    cookie.Value += id + ",";
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








    }
}