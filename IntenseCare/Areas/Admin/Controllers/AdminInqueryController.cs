using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntenseCare.Models;

namespace IntenseCare.Areas.Admin.Controllers
{
    public class AdminInqueryController : Controller
    {
        AppointmentEntities10 dc = new AppointmentEntities10();
        // GET: Admin/AdminInquery
        public ActionResult Index()
        {
            if (Session["loginid"] != null)
            {
                var ad = dc.tblAdminIquiries .ToList();
                return View(ad);
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
            
        }
        [HttpPost]
        public JsonResult Active(int id)
        {
            tblAdminIquiry  ad = dc.tblAdminIquiries .SingleOrDefault(ob => ob.AdminInquiryID  == id);
            if (ad.IsReply == true)
            {
                ad.IsReply = false;
            }
            else
            {
                ad.IsReply = true;
            }
            dc.SaveChanges();
            return Json(ad.IsReply, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Details(int id)
        {
            tblAdminIquiry  ad = dc.tblAdminIquiries .SingleOrDefault(ob => ob.AdminInquiryID  == id);
            return View(ad);
        }
    }
}