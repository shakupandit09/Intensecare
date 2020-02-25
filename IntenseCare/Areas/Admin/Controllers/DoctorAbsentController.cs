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
        public ActionResult Details(int id)
        {
            tblDoctorAbsence  ad = dc.tblDoctorAbsences .SingleOrDefault(ob => ob.DoctorAbsenceId  == id);
            ViewBag.DoctorName = (from ob in dc.tblDoctors where ob.DoctorId == ad.DoctorId select ob).Take(1).SingleOrDefault().FirstName;
            string name = ViewBag.DoctorName;
            return View(ad);
        }

    }
}