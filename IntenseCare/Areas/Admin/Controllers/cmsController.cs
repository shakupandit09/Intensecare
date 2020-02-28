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
        AppointmentEntities9 dc = new AppointmentEntities9();
        // GET: Admin/cms
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Index(string BlogContent, string PageTitle)
        {
            tblCMSPage cms = new tblCMSPage();
            cms.PageTittle = "PageTitle";
            cms.Description = BlogContent;
            cms.CreatedOn = DateTime.Now;
            cms.IsActive = true;
            dc.tblCMSPages.Add(cms);
            dc.SaveChanges();
            ViewBag.Content = BlogContent;
            return RedirectToAction("ViewCMS", new { Title = "PageTitle" });

        }
        public ActionResult ViewCMS(String Title)
        {
            tblCMSPage cms = dc.tblCMSPages.SingleOrDefault(ob => ob.PageTittle == Title);
            return View(cms);
        }

    }
}