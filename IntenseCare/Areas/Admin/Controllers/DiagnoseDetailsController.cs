using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntenseCare.Models;

namespace IntenseCare.Areas.Admin.Controllers
{
    public class DiagnoseDetailsController : Controller
    {
        AppointmentEntities10 dc = new AppointmentEntities10();
        // GET: Admin/DiagnoseDetails
        public ActionResult Index()
        {
            if (Session["loginid"] != null)
            {
                var DiagnoDocPatie = from ob in dc.tblDiagnoseDetails
                                    join ob2 in dc.tblDoctors on ob.DoctorId equals ob2.DoctorId
                                    join ob3 in dc.tblPatients on ob.PatientId equals ob3.PatientId
                                     join ob4 in dc.tblAdmitDetails  on ob.AdmitDetailId  equals ob4.AdmitDetailId 
                                     select new Datamodel
                                    {
                                        Diagnose = ob,
                                        Doctor = ob2,
                                        Patient = ob3,
                                        Admit = ob4,
                                    };
                return View(DiagnoDocPatie);
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
        }
        [HttpPost]
        public JsonResult Active(int id)
        {
            tblDiagnoseDetail ad = dc.tblDiagnoseDetails.SingleOrDefault(ob => ob.DiagnosisId == id);
            if (ad.IsFormReport == true)
            {
                ad.IsFormReport = false;
            }
            else
            {
                ad.IsFormReport = true;
            }
            dc.SaveChanges();
            return Json(ad.IsFormReport, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Details(int id)
        {
            tblDiagnoseDetail ad = dc.tblDiagnoseDetails .SingleOrDefault(ob => ob.DiagnosisId == id);
            ViewBag.DoctorName = (from ob in dc.tblDoctors where ob.DoctorId == ad.DoctorId select ob).Take(1).SingleOrDefault().FirstName;
            ViewBag.PatientName = (from ob1 in dc.tblPatients  where ob1.PatientId  == ad.PatientId  select ob1).Take(1).SingleOrDefault().FirstName;
            string name = ViewBag.DoctorName;
            string pname = ViewBag.patientName;
            return View(ad);
        }

    }
}