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
            var TitleList = from ob in dc.tblCMSPages select ob.PageTittle;
            ViewBag.PageTittle = TitleList;
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Index(string BlogContent, string PageTitle)
        {
            tblCMSPage cms = new tblCMSPage();
            cms.PageTittle = PageTitle;
            cms.Description = BlogContent;
            cms.CreatedOn = DateTime.Now;
            cms.IsActive = true;
            dc.tblCMSPages.Add(cms);
            dc.SaveChanges();
            ViewBag.Content = BlogContent;
            return RedirectToAction("ViewCMS", new { Title = "PageTitle" });
        }
        public ActionResult ViewCMS(int id = 1)
        {
            var TitleList = from ob in dc.tblCMSPages select ob;
            ViewBag.cms = TitleList;
            tblCMSPage cms = dc.tblCMSPages.SingleOrDefault(ob => ob.CMSPageId == id);
            return View(cms);

        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ViewCMS(string BlogContent, int id)
        {
            tblCMSPage cms = dc.tblCMSPages.SingleOrDefault(ob => ob.CMSPageId == id);
            cms.Description = BlogContent;
            dc.SaveChanges();
            return RedirectToAction("ViewCMS", "cms");
        }
        [HttpPost]
        public JsonResult Active(int id)
        {
            tblCMSPage ad = dc.tblCMSPages.SingleOrDefault(ob => ob.CMSPageId == id);
            if (ad.IsActive == true)
            {
                ad.IsActive = false;
            }
            else
            {
                ad.IsActive = true;
            }
            dc.SaveChanges();
            return Json(ad.IsActive, JsonRequestBehavior.AllowGet);
        }
    }
}