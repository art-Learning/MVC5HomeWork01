using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5HomeWork01.Models;

namespace MVC5HomeWork01.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            客戶資料Entities db = new 客戶資料Entities();
            var info = db.V_總覽;
            return View(info.ToList());
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}