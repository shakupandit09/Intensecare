using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntenseCare.Models;

namespace IntenseCare.Areas.Admin.Controllers
{
    public class AchievementController : Controller
    {
        AppointmentEntities9 dc = new AppointmentEntities9();
        // GET: Admin/Achievement
        public ActionResult Index()
        {
            if (Session["loginid"] != null)
            {
                var DoctorAchieve = from ob in dc.tblAchievements
                                   join ob2 in dc.tblDoctors on ob.DoctorId equals ob2.DoctorId
                                   select new Datamodel
                                   {
                                       
                                       Achieve= ob,
                                       Doctor = ob2,
                                   };
                return View(DoctorAchieve);
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }          
        }
        public ActionResult Detail(int id)
        {
            tblAchievement ad = dc.tblAchievements.SingleOrDefault(ob => ob.AchievementId == id);
            ViewBag.DoctorName = (from ob in dc.tblDoctors where ob.DoctorId == ad.DoctorId select ob).Take(1).SingleOrDefault().FirstName;
            string name = ViewBag.DoctorName;
            return View(ad);
        }
    }
}