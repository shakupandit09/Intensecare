using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntenseCare.Models;

namespace IntenseCare.Controllers
{
    public class AdInqueryController : Controller
    {
        AppointmentEntities10 dc = new AppointmentEntities10();
        // GET: AdInquery
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            tblAdminIquiry Adinq = new tblAdminIquiry();
            Adinq.FirtsName = form["txtFname"];
            Adinq.LastName = form["txtLname"];
            Adinq.ContactNo = form["txtContactNo"];
            Adinq.EmailID = form["txtEmail"];
            Adinq.Subject = form["txtSubject"];
            Adinq.Inquiry = form["txtQuery"];
            Adinq.InquiryOn = DateTime.Now;
            dc.tblAdminIquiries.Add(Adinq);
            dc.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}