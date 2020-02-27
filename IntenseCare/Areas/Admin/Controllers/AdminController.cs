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
            tblAdmin ad = (from ob in dc.tblAdmins where ob.Emailid == Email && ob.Password == Password select ob).Take(1).SingleOrDefault();
            if (ad != null)
            {
                Session["loginId"] = ad.AdminId;
                Session["loginname"] = ad.Name;
                return RedirectToAction("list","Admin");
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
            
            ad.CreatedBy = Convert.ToInt32(form["CreatedBy"]);
            ad.IsActive = true;
            ad.IsSuper = true;
            ad.IsInsert = true;
            ad.IsEdit = true;
            ad.IsDelete = true;
            ad.CreatedOn = DateTime.Now;
            dc.tblAdmins.Add(ad);
            dc.SaveChanges();
            return RedirectToAction("list","Admin");
        }
        //public string code()
        //{
        //    string code = DateTime.Now.ToString("dd-mm-yyyy-HH-mm-ss-ff").Replace("-", "");
        //    return code;
        //}
        public ActionResult Detail(int id)
        {
            tblAdmin ad = dc.tblAdmins.SingleOrDefault(ob => ob.AdminId == id);
            //ViewBag.AdminName = (from ob in dc.tblAdmins  where ob.AdminId  == ad.CreatedBy  select ob).Take(1).SingleOrDefault().Name;
            //string name = ViewBag.AdminName;
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
            ad.Emailid = form["Email"];
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
        //[HttpPost]
        //public JsonResult CheckEmail(string id)
        //{
        //    string response;
        //    tblAdmin user = dc.tblAdmins.SingleOrDefault(ob => ob.Emailid == id);
        //    if (user != null)
        //    {
        //        response = "true";
        //    }
        //    else
        //    {
        //        response = "false";
        //    }
        //    return Json(response, JsonRequestBehavior.AllowGet);
        //}


    }
}