using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntenseCare.Models;

namespace IntenseCare.Areas.Admin.Controllers
{
    public class DoctorInqueryController : Controller
    {
        AppointmentEntities10 dc = new AppointmentEntities10();
        // GET: Admin/DoctorInquery
        public ActionResult Index()
        {
            if (Session["loginid"] != null)
            {
                var reviewDoc = from ob in dc.tblDoctorInquiries 
                                join ob2 in dc.tblDoctors on ob.DoctorId equals ob2.DoctorId
                                join ob3 in dc.tblPatients on ob.PatientId equals ob3.PatientId
                                select new Datamodel
                                {
                                    DoctorInquiry  = ob,
                                    Doctor = ob2,
                                    Patient = ob3,
                                };
                return View(reviewDoc);
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
        }
        [HttpPost]
        public JsonResult Active(int id)
        {
            tblDoctorInquiry  ad = dc.tblDoctorInquiries .SingleOrDefault(ob => ob.DoctorInquiryID == id);
            if (ad.IsReply  == true)
            {
                ad.IsReply  = false;
            }
            else
            {
                ad.IsReply  = true;
            }
            dc.SaveChanges();
            return Json(ad.IsReply , JsonRequestBehavior.AllowGet);
        }
        public ActionResult Details(int id)
        {
            tblDoctorInquiry  ad = dc.tblDoctorInquiries .SingleOrDefault(ob => ob.DoctorInquiryID  == id);
            ViewBag.DoctorName = (from ob in dc.tblDoctors where ob.DoctorId == ad.DoctorId select ob).Take(1).SingleOrDefault().FirstName;
            ViewBag.PatientName = (from ob1 in dc.tblPatients where ob1.PatientId == ad.PatientId select ob1).Take(1).SingleOrDefault().FirstName;
            string name = ViewBag.DoctorName;
            string pname = ViewBag.patientName;
            return View(ad);
        }
    }
}