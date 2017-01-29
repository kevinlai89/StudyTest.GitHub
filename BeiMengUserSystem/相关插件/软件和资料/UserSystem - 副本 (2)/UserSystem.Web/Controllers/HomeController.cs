using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserSystem.Web.Controllers.Filter;

namespace UserSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        [CheckLoginFilter()]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserManger()
        {
            return View();
        }

    }
}
