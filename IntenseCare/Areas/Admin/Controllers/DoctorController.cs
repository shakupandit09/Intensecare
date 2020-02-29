using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntenseCare.Models;

namespace IntenseCare.Areas.Admin.Controllers
{
    public class DoctorController : Controller
    {
        AppointmentEntities10 dc = new AppointmentEntities10();
        // GET: Admin/Doctor
        public ActionResult Index()
        {
            if (Session["loginid"] != null)
            {
                var ad = dc.tblDoctors.ToList();
                return View(ad);
            }
            else
            {
                return RedirectToAction("Index","Admin");
            }
        }
        public ActionResult Add()
        {
            var country = dc.CountryMasters;
            ViewBag.country = new SelectList(country, "ID", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Add(FormCollection form , HttpPostedFileBase txtfile)
        {
            string name = "";
            if (txtfile != null)
            {
                int size = (int)txtfile.ContentLength / 1024;
                var extension = System.IO.Path.GetExtension(txtfile.FileName);
                if (size <= 1024 && (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png")))
                {
                    name = code() + "" + extension;
                    string path = Server.MapPath("~/Areas/image");
                    txtfile.SaveAs(path + "" + name);
                }
            }
            tblDoctor ad = new tblDoctor();
            ad.FirstName = form["FirstName"];
            ad.LastName = form["LastName"];
            ad.Password = form["Password"];
            ad.Email = form["Email"];
            ad.Gender = form["gen"];
            ad.ContactNo = form["ContactNo"];
            ad.DOB = Convert.ToDateTime(form["DOB"]);
            ad.Address = form["Address"];
            ad.CityID = Convert.ToInt32(form["ddCity"]);
            ad.Degree = form["Degree"];
            ad.YearOfExperience = Convert.ToInt32(form["YearOfExp"]);
            ad.IsActive = true;
            ad.IsVerified = true;
            ad.IsMobileVerified = true;
            ad.ApprovedBy = Convert.ToInt32(form["loginId"]);
            ad.ApprovedOn = DateTime.Now;
            ad.Specialization = form["Specialization"];
            ad.ProfileImageUrl= name.ToString();
            dc.tblDoctors.Add(ad);
            dc.SaveChanges();
            return RedirectToAction("Index", "Doctor");
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
        public ActionResult Detail(int id)
        {
            tblDoctor ad = dc.tblDoctors.SingleOrDefault(ob => ob.DoctorId == id);
            return View(ad);
        }
        public string code()
        {
            string code = DateTime.Now.ToString("dd-mm-yyyy-HH-mm-ss-ff").Replace("-", "");
            return code;
        }
        public ActionResult Delete(int id)
        {
            tblDoctor ad = dc.tblDoctors.SingleOrDefault(ob => ob.DoctorId == id);
            dc.tblDoctors.Remove(ad);
            dc.SaveChanges();
            return RedirectToAction("Index","Doctor");
        }
        public ActionResult Edit(int id)
        {
            TempData["UpdateId"] = id;
            tblDoctor ad = dc.tblDoctors.SingleOrDefault(ob => ob.DoctorId == id);

            return View(ad);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            int id = Convert.ToInt32(TempData["UpdateId"]);

            tblDoctor ad = dc.tblDoctors.SingleOrDefault(ob => ob.DoctorId == id);
            ad.FirstName = form["FirstName"];
            ad.LastName = form["LastName"];
            ad.Email = form["Email"];
            ad.ContactNo = form["ContactNo"];
            ad.Address = form["Address"];
            dc.SaveChanges();
            return RedirectToAction("list");
        }
        [HttpPost]
        public JsonResult Active(int id)
        {
            tblDoctor ad = dc.tblDoctors.SingleOrDefault(ob => ob.DoctorId == id);
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
        //public ActionResult tmp()
        //{
        //    return View();
        //}
       
    }  
}