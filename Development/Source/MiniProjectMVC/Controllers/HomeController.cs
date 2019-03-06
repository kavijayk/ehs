using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniProjectMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Home()
        {
            //if (Session["userType"] != null)
            //{
            //    Session["userType"] = Session["userType"].ToString();
            //    Session["userName"] = Session["userName"].ToString();
            //}
            return View();
        }
        public ActionResult Index()
        {           
            return View();
        }
    }
}