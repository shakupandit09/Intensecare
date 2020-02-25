using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntenseCare.Models;

namespace IntenseCare.Areas.Admin.Controllers
{
    public class FeedbackController : Controller
    {
        AppointmentEntities9 dc = new AppointmentEntities9();
        // GET: Admin/Feedback
        public ActionResult Index()
        {
            if (Session["loginid"] != null)
            {
                var ad = dc.tblFeedbacks.ToList();
                return View(ad);
            }
            else
            {
                return RedirectToAction("Index", "FeedBack");
            }

        }
        public ActionResult Details(int id)
        {
            tblFeedback  ad = dc.tblFeedbacks .SingleOrDefault(ob => ob.FeedbackId  == id);
            return View(ad);
        }
    }
}