using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntenseCare.Models;

namespace IntenseCare.Areas.Admin.Controllers
{
    public class PatientController : Controller
    {
        AppointmentEntities10 dc = new AppointmentEntities10();
        // GET: Admin/Patient
        public ActionResult Index()
        {
            if (Session["loginid"] != null)
            {
                var ad = dc.tblPatients.ToList();
                return View(ad);
            }
            else
            {
                return RedirectToAction("index", "Admin");
            }
           
        }
        [HttpPost]
        public JsonResult Active(int id)
        {
            tblPatient ad = dc.tblPatients.SingleOrDefault(ob => ob.PatientId == id);
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
        public ActionResult Detail(int id)
        {
            tblPatient ad = dc.tblPatients.SingleOrDefault(ob => ob.PatientId == id);
            return View(ad);
        }
    }
}