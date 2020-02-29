using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntenseCare.Models;

namespace IntenseCare.Areas.Admin.Controllers
{
    public class AdmitController : Controller
    {
        AppointmentEntities10 dc = new AppointmentEntities10();
        // GET: Admin/Admit
        public ActionResult Index()
        {
            if (Session["loginid"] != null)
            {
                var AdDocPatient = from ob in dc.tblAdmitDetails
                                    join ob2 in dc.tblDoctors on ob.DoctorId equals ob2.DoctorId
                                    join ob3 in dc.tblPatients on ob.PatientId equals ob3.PatientId
                                    join ob4 in dc.tblNurses on ob.NurseId equals ob4.NurseId
                                    select new Datamodel
                                    {
                                        Admit = ob,
                                        Doctor = ob2,
                                        Patient = ob3,
                                        Nurse = ob4,
                                    };
                return View(AdDocPatient);
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
            
        }
        public ActionResult registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult registration(FormCollection form)
        {
            tblAdmitDetail ad = new tblAdmitDetail ();
            ad.DoctorId = Convert.ToInt32(form ["DoctorId"]);
            ad.PatientId = Convert.ToInt32(form ["PatientId"]);
            ad.NurseId  = Convert.ToInt32(form["NurseId"]);
            
            ad.WardType  = form["WardType"];
            ad.WardNo = Convert.ToInt32(form["WardNo"]);
            ad.CreatedBy = Convert.ToInt32(Session["loginId"]);
            ad.ModifiedBy  = Convert.ToInt32(Session["loginId"]);
            ad.IsDischarge = true;
            ad.CreatedOn = DateTime.Now;
            ad.ModifiedOn  = DateTime.Now;
            dc.tblAdmitDetails.Add(ad);
            dc.SaveChanges();
            return RedirectToAction("Index", "Admit");
        }
        [HttpPost]
        public JsonResult Active(int id)
        {
            tblAdmitDetail  ad = dc.tblAdmitDetails .SingleOrDefault(ob => ob.AdmitDetailId  == id);
            if (ad.IsDischarge  == true)
            {
                ad.IsDischarge = false;
            }
            else
            {
                ad.IsDischarge = true;
            }
            dc.SaveChanges();
            return Json(ad.IsDischarge, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Details(int id)
        {
            tblAdmitDetail  ad = dc.tblAdmitDetails.SingleOrDefault(ob => ob.AdmitDetailId == id);
            ViewBag.DoctorName = (from ob in dc.tblDoctors where ob.DoctorId == ad.DoctorId select ob).Take(1).SingleOrDefault().FirstName;
            ViewBag.PatientName = (from ob1 in dc.tblPatients where ob1.PatientId == ad.PatientId select ob1).Take(1).SingleOrDefault().FirstName;
            ViewBag.NurseName = (from ob2 in dc.tblNurses  where ob2.NurseId  == ad.NurseId select ob2).Take(1).SingleOrDefault().FirstName;
           string name = ViewBag.DoctorName;
            string pname = ViewBag.patientName;
            string Nname = ViewBag.NurseName;
            return View(ad);
        }
        public ActionResult Delete(int id)
        {
            tblAdmitDetail  ad = dc.tblAdmitDetails .SingleOrDefault(ob => ob.AdmitDetailId == id);
            dc.tblAdmitDetails.Remove(ad);
            dc.SaveChanges();
            return RedirectToAction("Index","Admit");
        }
        public ActionResult Edit(int id)
        {
            TempData["UpdateId"] = id;
            tblAdmitDetail  ad = dc.tblAdmitDetails .SingleOrDefault(ob => ob.AdmitDetailId  == id);

            return View(ad);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            int id = Convert.ToInt32(TempData["UpdateId"]);

            tblAdmitDetail  ad = dc.tblAdmitDetails . SingleOrDefault(ob => ob.AdmitDetailId  == id);
            ad.DoctorId  = Convert.ToInt32(form["DoctorId"]);
            ad.PatientId  = Convert.ToInt32(form["PatientId"]);
            ad.NurseId  = Convert.ToInt32(form["NurseId"]);
            ad.WardType = form["WardType"];
            ad.WardNo = Convert.ToInt32(form["WardNo"]);
            dc.SaveChanges();
            return RedirectToAction("Index","Admit");
        }

    }
}