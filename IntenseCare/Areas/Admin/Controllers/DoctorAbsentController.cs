using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntenseCare.Models;

namespace IntenseCare.Areas.Admin.Controllers
{
    public class DoctorAbsentController : Controller
    {
        AppointmentEntities10 dc = new AppointmentEntities10();
        // GET: Admin/DoctorAbsent
        public ActionResult Index()
        {
            if (Session["loginid"] != null)
            {
                var DoctorAbsent = from ob in dc.tblDoctorAbsences
                                   join ob2 in dc.tblDoctors on ob.DoctorId equals ob2.DoctorId
                                   select new Datamodel
                                   {
                                       Absence = ob,
                                       Doctor = ob2,
                                   };
                return View(DoctorAbsent);
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }

        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(FormCollection form)
        {
            tblDoctorAbsence  ad = new tblDoctorAbsence ();
            ad.DoctorId = Convert.ToInt32(form["DoctorId"]);
            ad.FromDate = Convert.ToDateTime(form["FromDate"]);
            ad.ToDate = Convert.ToDateTime(form["ToDate"]);
            ad.FromTime = TimeSpan.Parse(form["FromTime"]);
            ad.CreatedOn = DateTime.Now;
            dc.tblDoctorAbsences.Add(ad);
            dc.SaveChanges();
            return RedirectToAction("Index", "DoctorAbsent");
        }

        public ActionResult Details(int id)
        {
            tblDoctorAbsence  ad = dc.tblDoctorAbsences .SingleOrDefault(ob => ob.DoctorAbsenceId  == id);
            tblDoctor doctor = (from ob1 in dc.tblDoctors where ob1.DoctorId == ad.DoctorId select ob1).Take(1).SingleOrDefault();
            ViewBag.DoctorName = "Dr." + doctor.FirstName + " " + doctor.LastName; ;
            return View(ad);
        }
        public ActionResult Delete(int id)
        {
            tblDoctorAbsence  ad = dc.tblDoctorAbsences .SingleOrDefault(ob => ob.DoctorAbsenceId  == id);
            dc.tblDoctorAbsences .Remove(ad);
            dc.SaveChanges();
            return RedirectToAction("list");
        }
        public ActionResult Edit(int id)
        {
            TempData["UpdateId"] = id;
            tblDoctorAbsence  ad = dc.tblDoctorAbsences .SingleOrDefault(ob => ob.DoctorAbsenceId == id);

            return View(ad);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            int id = Convert.ToInt32(TempData["UpdateId"]);

           tblDoctorAbsence  ad = dc.tblDoctorAbsences .SingleOrDefault(ob => ob.DoctorAbsenceId  == id);
            ad.DoctorId  = Convert.ToInt32(form["DoctorId"]);
            ad.FromTime = TimeSpan.Parse(form["FromTime"]);
            ad.ToDate  = Convert.ToDateTime(form["ToDate"]);
            ad.FromDate = Convert.ToDateTime(form["FromDate"]); 
            dc.SaveChanges();
            return RedirectToAction("Index","DoctorAbsent");
        }

    }
}