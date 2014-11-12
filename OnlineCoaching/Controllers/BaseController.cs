using OnlineCoaching.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCoaching.Controllers
{
    public class BaseController : Controller
    {
        public SessionState SessionState { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            SessionState = new SessionState();

            if (filterContext.HttpContext.Session != null && filterContext.HttpContext.Session["SessionState"] != null)
                SessionState = filterContext.HttpContext.Session["SessionState"] as SessionState;

            base.OnActionExecuting(filterContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Session != null)
                filterContext.HttpContext.Session["sessionState"] = SessionState;
            base.OnActionExecuted(filterContext);
        }
    }
}