using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntenseCare.Models;

namespace IntenseCare.Areas.Admin.Controllers
{
    public class PrescriptionDetailController : Controller
    {
        AppointmentEntities10 dc = new AppointmentEntities10();
        // GET: Admin/PrescriptionDetail
        public ActionResult Index()
        {
            if (Session["loginid"] != null)
            {
                var presdetails = from ob in dc.tblPrescriptionDetails
                                       join ob2 in dc.tblPrescriptions on ob.PrescriptionId equals ob2.PrescriptionId
                                   
                                       select new Datamodel
                                       {
                                          PresDetail = ob,
                                            Prescription = ob2,
                                        
                                       };
                return View(presdetails);
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
        }
    }
}