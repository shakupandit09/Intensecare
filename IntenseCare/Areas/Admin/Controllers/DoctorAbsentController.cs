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
        AppointmentEntities9 dc = new AppointmentEntities9();
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
            ViewBag.DoctorName = (from ob in dc.tblDoctors where ob.DoctorId == ad.DoctorId select ob).Take(1).SingleOrDefault().FirstName;
            string name = ViewBag.DoctorName;
            return View(ad);
        }
        //public ActionResult Delete(int id)
        //{
        //    tbl ad = dc.tblAdmins.SingleOrDefault(ob => ob.AdminId == id);
        //    dc.tblAdmins.Remove(ad);
        //    dc.SaveChanges();
        //    return RedirectToAction("list");
        //}
    }
}