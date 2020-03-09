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
        AppointmentEntities10 dc = new AppointmentEntities10();
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
        //public ActionResult Add()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Add(FormCollection form)
        //{
        //    tblAchievement ad = new tblAchievement();
        //    ad.DoctorId= Convert.ToInt32(form["did"]);
        //    ad.Achievement = form["achieve"];
        //    ad.AchievementDescription = form["achievedes"];
     
        //    ad.AchievedDate =Convert.ToDateTime(form["adate"]);
        //    dc.tblAchievements.Add(ad);
        //    dc.SaveChanges();
        //    return RedirectToAction("Index", "Achievement");
        //}

        public ActionResult Detail(int id)
        {
            tblAchievement ad = dc.tblAchievements.SingleOrDefault(ob => ob.AchievementId == id);
            tblDoctor doctor = (from ob1 in dc.tblDoctors where ob1.DoctorId == ad.DoctorId select ob1).Take(1).SingleOrDefault();
            ViewBag.DoctorName = "Dr." + doctor.FirstName + " " + doctor.LastName;

            //ViewBag.DoctorName = (from ob in dc.tblDoctors where ob.DoctorId == ad.DoctorId select ob).Take(1).SingleOrDefault().FirstName;
            //string name = ViewBag.DoctorName;
            return View(ad);
        }
    }
}