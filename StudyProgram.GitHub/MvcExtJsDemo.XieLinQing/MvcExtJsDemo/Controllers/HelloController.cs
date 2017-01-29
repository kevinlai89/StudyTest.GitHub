using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcExtJsDemo.Controllers
{
    public class HelloController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public ActionResult Test(String Info)
        {
            if (!String.IsNullOrEmpty(Info))
                return Content("{State:0,Message:'消息接收成功',Body:'" + Info + "'}", "Application/JSON");
            else
                return Content("{State:-1,Message:'没有传入消息！'}", "Application/JSON");
        }
    }
}
