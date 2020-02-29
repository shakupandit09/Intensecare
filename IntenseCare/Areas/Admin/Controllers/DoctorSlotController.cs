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
        AppointmentEntities10 dc = new AppointmentEntities10();
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
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(FormCollection form)
        {
            tblDoctorSlot  ad = new tblDoctorSlot ();
            ad.DoctorId = Convert.ToInt32(form["DoctorId"]);
            ad.StartTime = TimeSpan.Parse(form["StartTime"]);
            ad.DayWeek  = Convert.ToInt32(form["DayWeek"]);
            ad.EndTime  = TimeSpan.Parse(form["EndTime"]);
            ad.OpdShedule  = Convert.ToDateTime(form["OpdShedule"]);
            dc.tblDoctorSlots.Add(ad);
            dc.SaveChanges();
            return RedirectToAction("Index", "DoctorSlot");
        }
        public ActionResult Delete(int id)
        {
            tblDoctorSlot  ad = dc.tblDoctorSlots.SingleOrDefault(ob => ob.DoctorSlotId  == id);
            dc.tblDoctorSlots.Remove(ad);
            dc.SaveChanges();
            return RedirectToAction("Index","DoctorSlot");
        }
        public ActionResult Edit(int id)
        {
            TempData["UpdateId"] = id;
            tblDoctorSlot  ad = dc.tblDoctorSlots .SingleOrDefault(ob => ob.DoctorSlotId  == id);

            return View(ad);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            int id = Convert.ToInt32(TempData["UpdateId"]);

          tblDoctorSlot  ad = dc.tblDoctorSlots .SingleOrDefault(ob => ob.DoctorSlotId  == id);
            ad.DoctorId = Convert.ToInt32(form["DoctorId"]);
            ad.StartTime  = TimeSpan.Parse(form["StartTime"]);
            ad.EndTime  = TimeSpan.Parse(form["EndTime"]);
            ad.DayWeek  = Convert.ToInt32(form["DayWeek"]);
            ad.OpdShedule = Convert.ToDateTime(form["OpdShedule"]);
            dc.SaveChanges();
            return RedirectToAction("Index", "DoctorSlot");
        }
    }
}