﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntenseCare.Models;

namespace IntenseCare.Areas.Admin.Controllers
{
    public class PaymentController : Controller
    {
        AppointmentEntities10 dc = new AppointmentEntities10();
        // GET: Admin/Payment
        public ActionResult Index()
        {
            if (Session["loginid"] != null)
            {
                var patientdocpayment = from ob in dc.tblPayments
                                     join ob2 in dc.tblDoctors on ob.DoctorId equals ob2.DoctorId
                                     join ob3 in dc.tblPatients on ob.PatientId equals ob3.PatientId
                                     join ob4 in dc.tblAdmitDetails on ob.AdmitDetailId equals ob4.AdmitDetailId 
                                     select new Datamodel
                                     {
                                         payment = ob,
                                         Doctor = ob2,
                                         Patient = ob3,
                                         Admit = ob4,
                                     };
                return View(patientdocpayment);
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
        }
        public ActionResult Details(int id)
        {
            tblPayment  ad = dc.tblPayments.SingleOrDefault(ob => ob.PaymentId == id);
            ViewBag.DoctorName = (from ob in dc.tblDoctors where ob.DoctorId == ad.DoctorId select ob).Take(1).SingleOrDefault().FirstName;
            ViewBag.PatientName = (from ob1 in dc.tblPatients where ob1.PatientId == ad.PatientId select ob1).Take(1).SingleOrDefault().FirstName;
            string name = ViewBag.DoctorName;
            string pname = ViewBag.patientName;
            return View(ad);
        }
    }
}