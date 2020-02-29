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
            if (Session["loginid"] != null)
            {
                var ad = dc.tblCMSPages.ToList();
                return View(ad);
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Add(string BlogContent, string PageTitle)
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
        public ActionResult ViewCMS(string Title)
        {
            tblCMSPage cms = dc.tblCMSPages.SingleOrDefault(ob => ob.PageTittle == Title);
            return View(cms);
        }
        public ActionResult Edit(int id)
        {
            TempData["UpdateId"] = id;
            tblCMSPage ad = dc.tblCMSPages.SingleOrDefault(ob => ob.CMSPageId == id);
            return View(ad);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            int id = Convert.ToInt32(TempData["UpdateId"]);

           tblCMSPage ad = dc.tblCMSPages.SingleOrDefault(ob => ob.CMSPageId == id);
            ad.PageTittle = form["PageTittle"];
            ad.Description = form["Description"];
            dc.SaveChanges();
            return RedirectToAction("Index", "cms");
        }
    }
}