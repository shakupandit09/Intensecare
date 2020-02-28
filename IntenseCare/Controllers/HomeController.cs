using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using IntenseCare.Models;
using System.Net.Mail;

namespace IntenseCare.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Blank()
        {
            return View();
        }
        //readonly AppointmentEntities9 db = new AppointmentEntities9();

        //public ActionResult Index()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult ForgetPassword(string txtForgetEmail)
        //{
        //    tblDoctor user = db.tblDoctors.SingleOrDefault(ob => ob.Email == txtForgetEmail);

        //    if (user != null)
        //    {
        //        Session["LoginUserID"] = user.DoctorId;

        //        MailMessage Msg = new MailMessage("Intensecare2020@outlook.com", txtForgetEmail);
        //        Msg.Subject = "Password Recovery";
        //        Msg.Body = "Your OTP is : <h3>" + 1234 + "</h3>";
        //        Msg.IsBodyHtml = true;


        //        SmtpClient smtp = new SmtpClient();
        //        smtp.Host = "smtp.gmail.com";
        //        smtp.Port = 587;
        //        smtp.UseDefaultCredentials = false;
        //        smtp.EnableSsl = true;
        //        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

        //        NetworkCredential MyCredentials = new NetworkCredential("Intensecare2020@outlook.com", "nkp12345");
        //        smtp.Credentials = MyCredentials;

        //        smtp.Send(Msg);

        //        Session["OTP"] = "1234";
        //        return View();
        //    }
        //    else
        //    {
        //        ViewBag.Error = "Account Not Found";
        //        return View();
        //    }
        //}
        //public ActionResult ChangePassword()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public JsonResult Active(int id)
        //{
        //    tblPatient user = db.tblPatients.SingleOrDefault(ob => ob.PatientId == id);
        //    if (user.IsActive == true)
        //    {
        //        user.IsActive = false;
        //    }
        //    else
        //    {
        //        user.IsActive = true;
        //    }
        //    db.SaveChanges();
        //    return Json(user.IsActive, JsonRequestBehavior.AllowGet);
        //}
        //public ActionResult Delete(int id)
        //{
        //    tblPatient user = db.tblPatients.SingleOrDefault(ob => ob.PatientId == id);
        //    db.tblPatients.Remove(user);
        //    db.SaveChanges();
        //    return RedirectToAction("UserList");
        //}
        //[HttpPost]
        //public ActionResult Index(FormCollection form)
        //{
        //    string txtEmail = form["txtEmail"];
        //    string txtPass = form["txtPassword"];

        //    tblPatient user = db.tblPatients.SingleOrDefault(ob => ob.Email == txtEmail || ob.Password == txtPass);
        //    if (user != null)
        //    {
        //        Session["PatientID"] = user.PatientId;
        //        return RedirectToAction("PatientProfile", user);
        //    }
        //    else
        //        return View();
        //}
        //public ActionResult UserProfile(tblPatient user)
        //{
        //    if (user.PatientId != 0)
        //    {
        //        ViewBag.Year = user.CreatedOn.Value.Year.ToString();
        //        return View(user);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index");
        //    }
        //}
        //public ActionResult UserList()
        //{
        //    var userList = db.tblPatients.ToList();
        //    return View(userList);
        //}
        //public string AndroidLogin(string txtEmail = "", string txtPass = "")
        //{
        //    tblPatient user = db.tblPatients.SingleOrDefault(ob => ob.EmailId == txtEmail || ob.Password == txtPass);
        //    if (user != null)
        //        return "True";// txtEmail + " - " + txtPass; 
        //    //return Json("True", JsonRequestBehavior.AllowGet);
        //    else
        //        return "False";//
        //    //return Json("False", JsonRequestBehavior.AllowGet);
        //}
        //public ActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Create(FormCollection form)
        //{
        //    try
        //    {
        //        tblPatient user = new tblPatients();
        //        user.Name = form["Name"];
        //        user.Password = form["Password"];
        //        user.Email = form["Email"];
        //        user.ContactNo = form["ContactNo"];
        //        user.ProfPic = "user2.png";
        //        user.IsActive = true;
        //        user.CreatedOn = DateTime.Now;
        //        db.tblUsers.Add(user);
        //        db.SaveChanges();

        //        // Auto Login after Registration
        //        user = db.tblPatients
        //            .OrderByDescending(x => x.PatientId)
        //            .FirstOrDefault();
        //        Session["PatientID"] = user.PatientId;
        //        return RedirectToAction("PatientProfile", user);

        //    }
        //    catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
        //    {
        //        foreach (var validationErrors in dbEx.EntityValidationErrors)
        //        {
        //            foreach (var validationError in validationErrors.ValidationErrors)
        //            {
        //                string message = string.Format("{0}:{1}",
        //                    validationErrors.Entry.Entity.ToString(),
        //                    validationError.ErrorMessage);
        //                Response.Write(message);
        //                // Display Error on Screen if any
        //            }
        //        }
        //        return View();
        //    }
        //}
        //[HttpPost]
        //public JsonResult IsEmailExist(string Email)
        //{
        //    var User = (from ob in db.tblPatients where ob.EmailId == Email select ob);
        //    if (User.ToList().Count == 0)
        //    {
        //        return Json(true, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(false, JsonRequestBehavior.AllowGet);
        //    }
        //}
        //public ActionResult Logout()
        //{
        //    Session["PatientID"] = null;
        //    return RedirectToAction("Index");
        //}
        //[HttpPost]
        ////public ActionResult UploadImage(HttpPostedFileBase profimg)
        //{
        //    int ID = Convert.ToInt32(Session["UserID"]);
        //    tblPatient user = db.tblPatients.SingleOrDefault(ob => ob.PatientId == ID);
        //    user.ProfPic = profimg.FileName;
        //    db.SaveChanges();
        //    //string newImage = profimg.FileName;
        //    string path = Server.MapPath("~/images/");
        //    profimg.SaveAs(path + profimg.FileName);
        //    return View();
        //}
    }
}
