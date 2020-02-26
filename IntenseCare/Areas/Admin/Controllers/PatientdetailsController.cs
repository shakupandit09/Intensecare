using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntenseCare.Models;

namespace IntenseCare.Areas.Admin.Controllers
{
    public class PatientdetailsController : Controller
    {
        AppointmentEntities10 dc = new AppointmentEntities10();
        // GET: Admin/Patientdetails
        public ActionResult Index()
        {
            if (Session["loginid"] != null)
            {
                var patientAdmit = from ob in dc.tblPatientDetails
                                   join ob2 in dc.tblPatients on ob.PatientId equals ob2.PatientId
                                   join ob3 in dc.tblAdmitDetails on ob.AdmitDetailId  equals ob3.AdmitDetailId
                                   select new Datamodel
                                   {
                                       patientDetail  = ob,
                                       Patient = ob2,
                                       Admit  = ob3,
                                   };
                return View(patientAdmit);
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
        }
        [HttpPost]
        public JsonResult Active(int id)
        {
            tblPatientDetail ad = dc.tblPatientDetails.SingleOrDefault(ob => ob.PatientDetailId == id);
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
        public ActionResult Details(int id)
        {
            tblPatientDetail  ad = dc.tblPatientDetails.SingleOrDefault(ob => ob.PatientDetailId  == id);
            return View();
        }
    }
}