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
            tblPatient patient = (from ob2 in dc.tblPatients where ob2.PatientId == ad.PatientId select ob2).Take(1).SingleOrDefault();
            tblDoctor doctor = (from ob1 in dc.tblDoctors where ob1.DoctorId == ad.DoctorId select ob1).Take(1).SingleOrDefault();
            ViewBag.PatientName = patient.FirstName + " " + patient.LastName;
            ViewBag.DoctorName = "Dr." + doctor.FirstName + " " + doctor.LastName;
            //var patient = from ob2 in dc.tblPatients where ob2.PatientId == ad.PatientId select ob2;
            //var doctor = from ob1 in dc.tblDoctors where ob1.DoctorId == ad.DoctorId select ob1;
            //ViewBag.PatientName = patient;
            //ViewBag.DoctorName = doctor;
            return View(ad);
        }

    }
}