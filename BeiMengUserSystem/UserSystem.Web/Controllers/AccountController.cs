using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserSystem.Common;


namespace UserSystem.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
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
            //获取前台拿到的东西。
            string name = Request.Form["name"];
            string pwd = Request.Form["pwd"];
                        
            //后台的判断
            if (string.IsNullOrEmpty(name))
            {
                res = -1;
            }
            else
            {
                //去数据库判断。
                List<UserSystem.Model.UserManager> userList = userManager.GetModelList("name='" + name + "' and pwd='" + pwd + "'");
                if (userList.Count == 0)
                {
                    res = -2;
                }

            }
            return Content(res.ToString());
        }


        public ActionResult ReadUser()
        {
            string res = string.Empty;
            res = @"{""total"":28,""rows"":[
    {""productid"":""FI-SW-01"",""productname"":""Koi"",""unitcost"":10.00,""status"":""P"",""listprice"":36.50,""attr1"":""Large"",""itemid"":""EST-1""},
    {""productid"":""K9-DL-01"",""productname"":""Dalmation"",""unitcost"":12.00,""status"":""P"",""listprice"":18.50,""attr1"":""Spotted Adult Female"",""itemid"":""EST-10""},
    {""productid"":""RP-SN-01"",""productname"":""Rattlesnake"",""unitcost"":12.00,""status"":""P"",""listprice"":38.50,""attr1"":""Venomless"",""itemid"":""EST-11""},
    {""productid"":""RP-SN-01"",""productname"":""Rattlesnake"",""unitcost"":12.00,""status"":""P"",""listprice"":26.50,""attr1"":""Rattleless"",""itemid"":""EST-12""},
    {""productid"":""RP-LI-02"",""productname"":""Iguana"",""unitcost"":12.00,""status"":""P"",""listprice"":35.50,""attr1"":""Green Adult"",""itemid"":""EST-13""},
    {""productid"":""FL-DSH-01"",""productname"":""Manx"",""unitcost"":12.00,""status"":""P"",""listprice"":158.50,""attr1"":""Tailless"",""itemid"":""EST-14""},
    {""productid"":""FL-DSH-01"",""productname"":""Manx"",""unitcost"":12.00,""status"":""P"",""listprice"":83.50,""attr1"":""With tail"",""itemid"":""EST-15""},
    {""productid"":""FL-DLH-02"",""productname"":""Persian"",""unitcost"":12.00,""status"":""P"",""listprice"":23.50,""attr1"":""Adult Female"",""itemid"":""EST-16""},
    {""productid"":""FL-DLH-02"",""productname"":""Persian"",""unitcost"":12.00,""status"":""P"",""listprice"":89.50,""attr1"":""Adult Male"",""itemid"":""EST-17""},
    {""productid"":""AV-CB-01"",""productname"":""Amazon Parrot"",""unitcost"":92.00,""status"":""P"",""listprice"":63.50,""attr1"":""Adult Male"",""itemid"":""EST-18""}
]}
";

            return Content(res);
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

        public ActionResult LoadUser()
        {
            string res = string.Empty;
            int pageNum = Convert.ToInt32(Request.Form["page"]);
            int rowsNum = Convert.ToInt32(Request.Form["rows"]);

            System.Data.DataSet ds = userManager.GetAllList(pageNum,rowsNum);
            
            res = JsonHelper.ToJson(ds.Tables[0]);



            return Content(res.ToString());
        }
 
    }
}


//public ActionResult LoadUser()
//{
//    string res = string.Empty;
//    int pageNum = Convert.ToInt32(Request.Form["page"]);
//    int rowsNum = Convert.ToInt32(Request.Form["rows"]);
//    System.Data.DataSet ds = userManager.GetAllList(pageNum, rowsNum);
//    res = UserSystem.Common.JsonHelper.ToJson(ds.Tables[0]);
//    return Content(res.ToString());
//}