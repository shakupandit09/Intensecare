using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntenseCare.Models;

namespace IntenseCare.Areas.Admin.Controllers
{
    public class cmsController : Controller
    {
        AppointmentEntities10 dc = new AppointmentEntities10();
        // GET: Admin/cms
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Index(string BlogContent)
        {
            if (Session["loginid"] != null)
            {
            tblCMSPage cms = new tblCMSPage();
            cms.PageTittle = "cms1";
            cms.Description = BlogContent;
            cms.CreatedOn = DateTime.Now;
            cms.IsActive = true;
            dc.tblCMSPages.Add(cms);
            dc.SaveChanges();
            ViewBag.Description = BlogContent;
            return RedirectToAction("ViewCMS", new { Title = "cms1" });
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
        }
        public ActionResult ViewCMS(String Title)
        {
            tblCMSPage cms = dc.tblCMSPages.SingleOrDefault(ob => ob.PageTittle == Title);
            return View(cms);
        }
    }
}