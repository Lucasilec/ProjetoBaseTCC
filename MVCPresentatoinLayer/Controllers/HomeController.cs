using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPresentatoinLayer.Controllers
{
    public class HomeController : Controller
    {
        //meusite.com
        //meusite.com/Home
        //meusite.com/Home/Index
        public ActionResult Index()
        {
            return View();
        }

        //meusite.com/Home/About
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}