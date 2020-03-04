using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntenseCare.Models;

namespace IntenseCare.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        AppointmentEntities10 dc = new AppointmentEntities10();
        // GET: Admin/Admin
        public ActionResult Index()
        {
            Session.Clear();
            return View();
        }      
        [HttpPost]
        public ActionResult Index(string Email, string Password)
        {
            tblAdmin ad = (from ob in dc.tblAdmins where ob.Emailid == Email && ob.Password == Password && ob.IsActive == true select ob).Take(1).SingleOrDefault();
            if (ad != null)
            {
                Session["loginId"] = ad.AdminId;
                Session["loginname"] = ad.Name;
                return RedirectToAction("Dashboard", "Admin");
            }

            else
            {
                return View();
            }
        }
        public ActionResult Blank()
        {
            return View();
        }
        public ActionResult list()
        {
            if (Session["loginid"] != null)
            {
                var ad = dc.tblAdmins.ToList();
                return View(ad);
            }
            else
            {
                return RedirectToAction("index");
            }
        }
        public ActionResult registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult registration(FormCollection form)
        {
            tblAdmin ad = new tblAdmin();
            ad.Name = form["Name"];
            ad.Password = form["Password"];
            ad.Emailid = form["Email"];
            ad.ContactNo = form["ContactNo"];
            
            ad.CreatedBy = Convert.ToInt32(Session["loginId"]);
            ad.IsActive = true;
            ad.IsSuper = true;
            ad.IsInsert = true;
            ad.IsEdit = true;
            ad.IsDelete = true;
            ad.CreatedOn = DateTime.Now;
            dc.tblAdmins.Add(ad);
            dc.SaveChanges();
            return RedirectToAction("Index","Admin");
        }
        [HttpPost]
        public JsonResult CheckEmail(string id)
        {
            string response;
            tblAdmin user = dc.tblAdmins.SingleOrDefault(ob => ob.Emailid == id);
            if (user != null)
            {
                response = "true";
            }
            else
            {
                response = "false";
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult CheckCno(string id)
        {
            string response;
            tblAdmin user = dc.tblAdmins.SingleOrDefault(ob => ob.ContactNo == id);
            if (user != null)
            {
                response = "true";
            }
            else
            {
                response = "false";
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Detail(int id)
        {
            tblAdmin ad = dc.tblAdmins.SingleOrDefault(ob => ob.AdminId == id);
            return View(ad);
        }
        public ActionResult Delete(int id)
        {
            tblAdmin ad = dc.tblAdmins.SingleOrDefault(ob => ob.AdminId == id);
            dc.tblAdmins.Remove(ad);
            dc.SaveChanges();
            return RedirectToAction("list");
        }
        public ActionResult Edit(int id)
        {
            TempData["UpdateId"] = id;
            tblAdmin ad = dc.tblAdmins.SingleOrDefault(ob => ob.AdminId == id);

            return View(ad);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            int id = Convert.ToInt32(TempData["UpdateId"]);

            tblAdmin ad = dc.tblAdmins.SingleOrDefault(ob => ob.AdminId == id);
            ad.Name = form["Name"];
            //ad.Emailid = form["Email"];
            ad.ContactNo = form["ContactNo"];
            dc.SaveChanges();
            return RedirectToAction("list");
        }
        [HttpPost]
        public JsonResult Active(int id)
        {
            tblAdmin ad = dc.tblAdmins.SingleOrDefault(ob => ob.AdminId == id);
            if (ad.IsActive == true)
            {
                ad.IsActive = false;
            }
            else
            {
                ad.IsActive = true;
            }
            dc.SaveChanges();
            return Json(ad.IsActive, JsonRequestBehavior.AllowGet);
        }
       
        public ActionResult Dashboard()
        {
            ViewBag.DoctorCount = (from ob in dc.tblDoctors where ob.IsActive == true select ob).ToList().Count().ToString();
            ViewBag.PatientCount = (from ob in dc.tblPatients select ob).ToList().Count().ToString();
            ViewBag.AppointmentCount = (from ob in dc.tblAppoinments select ob).ToList().Count().ToString();
            ViewBag.AdmitCount = (from ob in dc.tblAdmitDetails select ob).ToList().Count().ToString();
            ViewBag.NurseCount = (from ob in dc.tblNurses select ob).ToList().Count().ToString();
            return View();
        }
        public ActionResult Schart()
        {
            var doctor = from ob in dc.tblDoctors where ob.IsActive == true select ob;
            string[] x = new string[doctor.ToList().Count];
            int[] y = new int[doctor.ToList().Count];
            int i = 0;
            foreach(tblDoctor d in doctor)
            {
                x[i] = d.DoctorId.ToString();
                y[i] = (from ob in dc.tblAppoinments where ob.DoctorID == d.DoctorId select ob).ToList().Count;
                i++;
            }
            ViewBag.x = x;
            ViewBag.y = y;
            return View();
        }
        public ActionResult Schart2()
        {
            var patient = (from ob in dc.tblAppoinments where ob.Appointment_date.Year == DateTime.Now.Year select ob.Appointment_date.Month).Distinct();
            string[] x = new string[patient.ToList().Count];
            int[] y = new int[patient.ToList().Count];
            int i = 0;
            foreach (int Month in patient)
            {
                x[i] = Month.ToString();
                y[i] = (from ob in dc.tblAppoinments where ob.Appointment_date.Month == Month && ob.Appointment_date.Year == DateTime.Now.Year select ob).ToList().Count;
                i++;
            }
            ViewBag.x = x;
            ViewBag.y = y;
            return View();
        }
        public ActionResult Schart3()
        {
            var patient = from ob in dc.tblPatientDetails where ob.IsActive == true select ob;
            string[] x = new string[patient.ToList().Count];
            int[] y = new int[patient.ToList().Count];
            int i = 0;
            foreach (tblPatientDetail p in patient)
            {
                x[i] = p.PatientDetailId.ToString();
                y[i] = (from ob in dc.tblAdmitDetails where ob.AdmitDetailId == p.PatientDetailId select ob).ToList().Count;
                i++;
            }
            ViewBag.x = x;
            ViewBag.y = y;
            return View();
        }
        public ActionResult Schart4()
        {
            var patient = from ob in dc.tblPatientDetails where ob.IsActive == true select ob;
            string[] x = new string[patient.ToList().Count];
            int[] y = new int[patient.ToList().Count];
            int i = 0;
            foreach (tblPatientDetail p in patient)
            {
                x[i] = p.PatientDetailId.ToString();
                y[i] = (from ob in dc.TblInHouseTreatements where ob.InHouseTreatementId == p.PatientDetailId select ob).ToList().Count;
                i++;
            }
            ViewBag.x = x;
            ViewBag.y = y;
            return View();
        }



    }
}