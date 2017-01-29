using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserSystem.Web.Controllers.Filter
{
    public class CheckLoginFilter : FilterAttribute, IActionFilter
    {

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (HttpContext.Current.Session["user"] == null)
            {
                filterContext.HttpContext.Response.Write("-1");
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["user"] == null)
            {
               //filterContext.HttpContext.Response.Write("-1");
                try
                {
                    filterContext.Result = new RedirectResult("/Account/Login");
                }
                catch (Exception)
                {
                    filterContext.Result = new RedirectResult("/Common/Error");
                }
            }
        }
    }
}