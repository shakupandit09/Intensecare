using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using IntenseCare.Models;

namespace IntenseCare.Areas.Admin.Controllers
{
    public class AdminInqueryController : Controller
    {
        AppointmentEntities10 dc = new AppointmentEntities10();
        // GET: Admin/AdminInquery
        public ActionResult Index()
        {
            var Inqs = from ob in dc.tblAdminIquiries where ob.IsReply == false select ob;

            return View(Inqs);
           
        }
        public ActionResult Details(int id)
        {
            tblAdminIquiry Inq = dc.tblAdminIquiries.SingleOrDefault(ob => ob.AdminInquiryID == id);

            return View(Inq);
        }
        [HttpPost]
        public ActionResult Details(FormCollection form, int id)
        {
            tblAdminIquiry Inq = dc.tblAdminIquiries.SingleOrDefault(ob => ob.AdminInquiryID == id);
            Inq.Reply = form["txtReply"];
            Inq.ReplyBy = Convert.ToInt32(Session["LoginID"]);
            Inq.IsReply = true;
            dc.SaveChanges();

            // Email Code 
            MailMessage Msg = new MailMessage("Intensecare2020@gmail.com", Inq.EmailID);
            Msg.Subject = "Reply of Your Inquiry";
            Msg.Body = form["txtReply"];
            Msg.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            NetworkCredential MyCredentials = new NetworkCredential("Intensecare2020@gmail.com", "Ss@12345");
            smtp.Credentials = MyCredentials;

            smtp.Send(Msg);

            return RedirectToAction("index");
        }
    }
}
        
 
