using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using IntenseCare.Models;
using System.Net.Mail;

namespace IntenseCare.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page";
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your Contact page";
            return View();
        }
        public ActionResult Blank()
        {
            return View();
        }
      
    }
}
