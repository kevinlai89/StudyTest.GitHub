﻿using System.Web;
using System.Web.Mvc;

namespace ASP.NET_MVC5_EF6
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
