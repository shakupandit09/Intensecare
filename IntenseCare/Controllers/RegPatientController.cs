using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntenseCare.Models;

namespace IntenseCare.Controllers
{
    public class RegPatientController : Controller
    {
        AppointmentEntities10 dc = new AppointmentEntities10();
        // GET: RegPatient
        public ActionResult Index()
        {
            
                return View();
          }
        public ActionResult Add()
        {
            var country = dc.CountryMasters;
            ViewBag.country = new SelectList(country, "ID", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Add(FormCollection form, HttpPostedFileBase txtfile)
        {
           tblPatient ad = new tblPatient();
            ad.FirstName = form["FirstName"];
            ad.LastName = form["LastName"];
            //ad.Pin = Convert.ToInt32(form["Pin"]);
            ad.EmailId = form["Email"];
            ad.Gender = form["Gen"];
            ad.ContactNo = form["ContactNo"];
            ad.Address = form["Address"];
            ad.CityId = Convert.ToInt32(form["ddCity"]);
            ad.IsActive = true;
            ad.IsVerified = true;
            ad.IsMobileVerified = true;
            ad.CreatedOn = DateTime.Now;
            ad.DateOFBirth = Convert.ToDateTime(form["DOB"]);
            ad.History = form["History"];
            ad.ReferencedBy = Convert.ToInt32(form["ReferencedBy"]);
            ad.NomineeName = form["NomineeName"];
            ad.NomineeContactNo = form["NomineeContactNo"];
            ad.NomineeAddress = form["NomineeAddress"];
            dc.SaveChanges();
            return View();

        }
        [HttpPost]
        public JsonResult getstate(int cid)
        {
            var state = from ob in dc.StateMasters where ob.CountryID == cid select ob;
            SelectList statelist = new SelectList(state, "ID", "Name");
            return Json(statelist, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult getcity(int sid)
        {
            var city = from ob in dc.CityMasters where ob.StateID == sid select ob;
            SelectList citylist = new SelectList(city, "ID", "Name");
            return Json(citylist, JsonRequestBehavior.AllowGet);
        }

    }
    }

