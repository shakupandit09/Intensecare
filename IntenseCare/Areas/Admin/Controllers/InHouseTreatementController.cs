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
        AppointmentEntities9 dc = new AppointmentEntities9();
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
            ViewBag.DoctorName = (from ob in dc.tblDoctors where ob.DoctorId == ad.DoctorId select ob).Take(1).SingleOrDefault().FirstName;
            ViewBag.PatientName = (from ob1 in dc.tblPatients where ob1.PatientId == ad.PatientId select ob1).Take(1).SingleOrDefault().FirstName;
            ViewBag.NurseName = (from ob2 in dc.tblNurses  where ob2.NurseId  == ad.NurseId  select ob2).Take(1).SingleOrDefault().FirstName;
            string name = ViewBag.DoctorName;
            string nname = ViewBag.DoctorName;
            string pname = ViewBag.patientName;
            return View(ad);
        }
    }
}