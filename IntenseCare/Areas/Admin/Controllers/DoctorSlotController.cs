using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntenseCare.Models;

namespace IntenseCare.Areas.Admin.Controllers
{
    public class DoctorSlotController : Controller
    {
        AppointmentEntities9 dc = new AppointmentEntities9();
        // GET: Admin/DoctorSlot
        public ActionResult Index()
        {
            if (Session["loginid"] != null)
            {
                var DoctorSolt = from ob in dc.tblDoctorSlots
                                   join ob2 in dc.tblDoctors on ob.DoctorId equals ob2.DoctorId
                                   select new Datamodel
                                   {
                                       Slot = ob,
                                       Doctor = ob2,
                                   };
                return View(DoctorSolt);
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }          
        }
        public ActionResult Details(int id)
        {
            tblDoctorSlot  ad = dc.tblDoctorSlots .SingleOrDefault(ob => ob.DoctorSlotId == id);
            ViewBag.DoctorName = (from ob in dc.tblDoctors where ob.DoctorId == ad.DoctorId select ob).Take(1).SingleOrDefault().FirstName;
            string name = ViewBag.DoctorName;
            return View(ad);
        }
    }
}