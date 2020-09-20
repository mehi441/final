using FinalElectron.DAL;
using FinalElectron.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalElectron.Areas.Admin.Controllers
{
    public class ContactController : Controller
    {
        // GET: Admin/Contact
        private ElectronContex db = new ElectronContex();

        public ActionResult Index()
        {
            return View(db.Contacts.ToList());
        }

        // GET: Admin/Contact/Delete/5
        public ActionResult Delete(int id)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact!=null)
            {
                db.Contacts.Remove(contact);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
