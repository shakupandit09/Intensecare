using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntenseCare.Models;

namespace IntenseCare.Areas.Admin.Controllers
{
    public class PatientController : Controller
    {
        AppointmentEntities10 dc = new AppointmentEntities10();
        // GET: Admin/Patient
        public ActionResult Index()
        {
            if (Session["loginid"] != null)
            {
                var ad = dc.tblPatients.ToList();
                return View(ad);
            }
            else
            {
                return RedirectToAction("index", "Admin");
            }
           
        }
        //public ActionResult Add()
        //{
        //    var country = dc.CountryMasters;
        //    ViewBag.country = new SelectList(country, "ID", "Name");
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Add(FormCollection form)
        //{
        //    tblPatient ad = new tblPatient();
        //    ad.FirstName = form["FirstName"];
        //    ad.LastName = form["LastName"];
        //    ad.Pin = Convert.ToInt32(form["Pin"]);
        //    ad.EmailId = form["Email"];
        //    ad.Gender = form["Gen"];
        //    ad.ContactNo = form["ContactNo"];
        //    ad.Address = form["Address"];
        //    ad.DateOFBirth = Convert.ToDateTime(form["DOB"]);
           
        //    ad.CityId = Convert.ToInt32(form["ddCity"]);
        //    ad.History = form["History"];
        //    if (form["ReferencedBy"] == "")
        //    {
        //        ad.ReferencedBy = 0;
        //    }
        //    else
        //    {

        //        ad.ReferencedBy = Convert.ToInt32(form["ReferencedBy"]);
        //    }
        //    ad.IsActive = true;
        //    ad.IsVerified = true;
        //    ad.IsMobileVerified = true;
        //    //ad. = Convert.ToInt32(Session["loginId"]);
        //    ad.CreatedOn = DateTime.Now;
        //    ad.NomineeName = form["NomineeName"];
        //    //ad.NomineeAddress = form["NomineeAddress"];
        //    ad.NomineeContactNo = form["NomineeContactNo"];
        //    //ad.ProfileImageUrl = name.ToString();
        //    dc.tblPatients.Add(ad);
        //    dc.SaveChanges();
        //    return RedirectToAction("Index", "Doctor");
        //}
        //[HttpPost]
        //public JsonResult getstate(int cid)
        //{
        //    var state = from ob in dc.StateMasters where ob.CountryID == cid select ob;
        //    SelectList statelist = new SelectList(state, "ID", "Name");
        //    return Json(statelist, JsonRequestBehavior.AllowGet);
        //}
        //[HttpPost]
        //public JsonResult getcity(int sid)
        //{
        //    var city = from ob in dc.CityMasters where ob.StateID == sid select ob;
        //    SelectList citylist = new SelectList(city, "ID", "Name");
        //    return Json(citylist, JsonRequestBehavior.AllowGet);
        //}
        [HttpPost]
        public JsonResult Active(int id)
        {
            tblPatient ad = dc.tblPatients.SingleOrDefault(ob => ob.PatientId == id);
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
        [HttpPost]
        public JsonResult CheckEmail(string id)
        {
            string response;
            tblPatient user = dc.tblPatients.SingleOrDefault(ob => ob.EmailId == id);
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
            tblPatient user = dc.tblPatients.SingleOrDefault(ob => ob.ContactNo == id);
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
            tblPatient ad = dc.tblPatients.SingleOrDefault(ob => ob.PatientId == id);
            tblDoctor doctor = (from ob2 in dc.tblDoctors where ob2.DoctorId == ad.ReferencedBy select ob2).Take(1).SingleOrDefault();
            ViewBag.DoctorName = doctor.FirstName + " " + doctor.LastName;
            CityMaster city = (from ob3 in dc.CityMasters where ob3.ID == ad.CityId select ob3).Take(1).SingleOrDefault();
            ViewBag.CityName = city.Name;
            return View(ad);
        }
    }
}