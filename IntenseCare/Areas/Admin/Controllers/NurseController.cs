using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntenseCare.Models;

namespace IntenseCare.Areas.Admin.Controllers
{
    public class NurseController : Controller
    {
        AppointmentEntities10 dc = new AppointmentEntities10();
        // GET: Admin/Nurse
        public ActionResult Index()
        {
            if (Session["loginid"] != null)
            {
                var ad = dc.tblNurses.ToList();
                return View(ad);
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }

        }
        public ActionResult registration()
        {
            var country = dc.CountryMasters;
            ViewBag.country = new SelectList(country, "ID", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult registration(FormCollection form, HttpPostedFileBase txtfile)
        {
            tblNurse  ad = new tblNurse ();
            ad.FirstName = form["FirstName"];
            ad.LastName = form["LastName"];
            ad.Pin = Convert.ToInt32(form["Pin"]);
            ad.EmailId  = form["Email"];
            ad.Gender = form["gen"];
            ad.ContactNo = form["ContactNo"];
            ad.Address = form["Address"];
            ad.CityId = Convert.ToInt32(form["ddCity"]);
            ad.IsActive = true;
            ad.IsVerified = true;
            ad.IsMobileVerified = true;
            ad.CreatedBy = Convert.ToInt32(Session["loginId"]);
            ad.CreatedOn = DateTime.Now;           
            dc.tblNurses .Add(ad);
            dc.SaveChanges();
            return RedirectToAction("Index", "Nurse");
            //return View();
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
        [HttpPost]
        public JsonResult Active(int id)
        {
            tblNurse ad = dc.tblNurses.SingleOrDefault(ob => ob.NurseId == id);
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
        public ActionResult Detail(int id)
        {
            tblNurse ad = dc.tblNurses.SingleOrDefault(ob => ob.NurseId == id);           
            return View(ad);
        }
        public ActionResult Edit(int id)
        {
            TempData["UpdateId"] = id;
            tblNurse  ad = dc.tblNurses .SingleOrDefault(ob => ob.NurseId == id);

            return View(ad);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            int id = Convert.ToInt32(TempData["UpdateId"]);

            tblNurse  ad = dc.tblNurses .SingleOrDefault(ob => ob.NurseId  == id);
            ad.FirstName = form["FirstName"];
            ad.LastName = form["LastName"];
            ad.EmailId  = form["Email"];
            ad.ContactNo = form["ContactNo"];
            ad.Address = form["Address"];
            dc.SaveChanges();
            return RedirectToAction("Index","Nurse");
        }
        public ActionResult Delete(int id)
        {
            tblNurse  ad = dc.tblNurses .SingleOrDefault(ob => ob.NurseId  == id);
            dc.tblNurses .Remove(ad);
            dc.SaveChanges();
            return RedirectToAction("Index", "Nurse");
        }
    }
}