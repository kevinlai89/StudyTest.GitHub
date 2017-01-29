using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserSystem.Web.Controllers.Filter;

namespace UserSystem.Web.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        UserSystem.Business.UserManager userManager = new Business.UserManager();

        public ActionResult DoLogin()
        {
            int res = 0;

            //获取前台js传过来的用户名和密码
            string name = Request.Form["name"];
            string pwd = Request.Form["pwd"];

            //后台的判断
            if (string.IsNullOrEmpty(name))
            {
                res = -1;
            }
            else
            {
                //去数据库做判断
               List<UserSystem.Model.UserManager> userList =  userManager.GetModelList(" name = '"+name+"' and pwd = '"+pwd+"'");
               if (userList.Count == 0)
               {
                   res = -2;
               }
               else
               {
                   //登录成功
                   Session["user"] = userList[0];
               }
                 
            }
            return Content(res.ToString());
        }

        public ActionResult DoLogoff()
        {
            int res = 0;

            try
            {
                Session.RemoveAll();
                Session.Clear();
            }
            catch (Exception)
            {
                res = -1;
            }

            return Content(res.ToString());
        }

        public ActionResult ReadUser()
        {
            string res = string.Empty;
            res = @"{""total"":28,""rows"":[
	{""ID"":""FI-SW-01"",""Name"":""Koi"",""Pwd"":10.00,""AddTime"":""P"",""listprice"":36.50,""attr1"":""Large"",""itemid"":""EST-1""},
	{""ID"":""K9-DL-01"",""Name"":""Dalmation"",""Pwd"":12.00,""AddTime"":""P"",""listprice"":18.50,""attr1"":""Spotted Adult Female"",""itemid"":""EST-10""},
	{""ID"":""RP-SN-01"",""Name"":""Rattlesnake"",""Pwd"":12.00,""AddTime"":""P"",""listprice"":38.50,""attr1"":""Venomless"",""itemid"":""EST-11""},
	{""ID"":""RP-SN-01"",""Name"":""Rattlesnake"",""Pwd"":12.00,""AddTime"":""P"",""listprice"":26.50,""attr1"":""Rattleless"",""itemid"":""EST-12""},
	{""ID"":""RP-LI-02"",""Name"":""Iguana"",""Pwd"":12.00,""AddTime"":""P"",""listprice"":35.50,""attr1"":""Green Adult"",""itemid"":""EST-13""},
	{""ID"":""FL-DSH-01"",""Name"":""Manx"",""Pwd"":12.00,""AddTime"":""P"",""listprice"":158.50,""attr1"":""Tailless"",""itemid"":""EST-14""},
	{""ID"":""FL-DSH-01"",""Name"":""Manx"",""Pwd"":12.00,""AddTime"":""P"",""listprice"":83.50,""attr1"":""With tail"",""itemid"":""EST-15""},
	{""ID"":""FL-DLH-02"",""Name"":""Persian"",""Pwd"":12.00,""AddTime"":""P"",""listprice"":23.50,""attr1"":""Adult Female"",""itemid"":""EST-16""},
	{""ID"":""FL-DLH-02"",""Name"":""Persian"",""Pwd"":12.00,""AddTime"":""P"",""listprice"":89.50,""attr1"":""Adult Male"",""itemid"":""EST-17""},
	{""ID"":""AV-CB-01"",""Name"":""Amazon Parrot"",""Pwd"":92.00,""AddTime"":""P"",""listprice"":63.50,""attr1"":""Adult Male"",""itemid"":""EST-18""}
]}
";
            return Content(res);
        }

        public ActionResult LoadUser()
        {
            string res = string.Empty;
            int pageNum = Convert.ToInt32(Request.Form["page"]);
            int rowsNum = Convert.ToInt32(Request.Form["rows"]);
            System.Data.DataSet ds = userManager.GetAllList(pageNum,rowsNum);
            res = UserSystem.Common.JsonHelper.ToJson(ds.Tables[0]);
            return Content(res.ToString());
        }

        public ActionResult AddUser()
        {
            string name = Request.Form["name"];
            string pwd = Request.Form["pwd"];
            int res = 0;
            UserSystem.Model.UserManager u = new Model.UserManager();
            u.Name = name;
            u.Pwd = pwd;
            u.AddTime = DateTime.Now.ToString();
            res = userManager.Add(u);
            return Content(res.ToString());
        }
    }
}
