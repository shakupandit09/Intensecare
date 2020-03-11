using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntenseCare.Models;

namespace IntenseCare.Areas.Admin.Controllers
{
    public class InHouseTreatementController : Controller
    {
        AppointmentEntities10 dc = new AppointmentEntities10();
        // GET: Admin/InHouseTreatement
        public ActionResult Index()
        {
            if (Session["loginid"] != null)
            {
                var DoctorHteart = from ob in dc.TblInHouseTreatements
                                 join ob2 in dc.tblDoctors on ob.DoctorId equals ob2.DoctorId
                                 join ob3 in dc.tblPatients on ob.PatientId equals ob3.PatientId
                                 join ob4 in dc.tblAdmitDetails on ob.AdmitDetailId equals ob4.AdmitDetailId 
                                 join ob5 in dc.tblNurses on ob.NurseId equals ob5.NurseId 
                                 select new Datamodel
                                 {
                                     HTreat = ob,
                                     Doctor = ob2,
                                     Patient = ob3,
                                     Admit = ob4,
                                     Nurse = ob5,
                                 };
                return View(DoctorHteart);
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
        }
        public ActionResult Details(int id)
        {
           TblInHouseTreatement ad = dc.TblInHouseTreatements.SingleOrDefault(ob => ob.InHouseTreatementId== id);
            tblPatient patient = (from ob2 in dc.tblPatients where ob2.PatientId == ad.PatientId select ob2).Take(1).SingleOrDefault();
            tblDoctor doctor = (from ob1 in dc.tblDoctors where ob1.DoctorId == ad.DoctorId select ob1).Take(1).SingleOrDefault();
            tblNurse  Nurse = (from ob3 in dc.tblNurses where ob3.NurseId == ad.NurseId select ob3).Take(1).SingleOrDefault();
            ViewBag.NurseName = Nurse.FirstName + " " + Nurse.LastName;
            ViewBag.PatientName = patient.FirstName + " " + patient.LastName;
            ViewBag.DoctorName = "Dr." + doctor.FirstName + " " + doctor.LastName;
            return View(ad);
        }
    }
}