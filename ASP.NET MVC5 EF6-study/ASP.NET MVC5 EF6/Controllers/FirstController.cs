using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_MVC5_EF6.Controllers
{
    public class FirstController : Controller
    {
        // GET: First
        public ActionResult Index()
        {
            ViewBag.slaks = new List<string> { "34534534", "222", "linda" };
            return View();

        }

        public string Index1()
        {
            return "<h1>This is index page1111111111</h1>";
        }
        public string Index2()
        {
            return "<h1>This is index page222222222222</h1>";
        }
    }
}