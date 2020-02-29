using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntenseCare.Models;

namespace IntenseCare.Areas.Admin.Controllers
{
    public class NewsLetterController : Controller
    {
        AppointmentEntities10 dc = new AppointmentEntities10();
        // GET: Admin/NewsLetter
        public ActionResult Index()
        {
            if (Session["loginid"] != null)
            {
                var ad = dc.tblNewsLetters.ToList();
                return View(ad);
            }
            else
            {
                return RedirectToAction("Index", "NewsLetter");
            }
        }
        [HttpPost]
        public JsonResult Active(int id)
        {
            tblNewsLetter ad = dc.tblNewsLetters.SingleOrDefault(ob => ob.NewsLetterId == id);
            if (ad.IsSubscribed == true)
            {
                ad.IsSubscribed = false;
            }
            else
            {
                ad.IsSubscribed = true;
            }
            dc.SaveChanges();
            return Json(ad.IsSubscribed, JsonRequestBehavior.AllowGet);
        }
    }
}