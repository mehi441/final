using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalElectron.Areas.Admin.Filters
{
    public class logout : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Admin"]==null)
            {
                filterContext.Result = new RedirectResult("~/Admin/Home/Login");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}