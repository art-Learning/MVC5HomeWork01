using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5HomeWork01.Models;

namespace MVC5HomeWork01.Controllers
{
    public class 客戶聯絡人Controller : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();
        // GET: 客戶聯絡人
        public ActionResult Index(int? id)
        {
            IQueryable<客戶聯絡人> List;
            if (id == null) {
                List = db.客戶聯絡人;
            } else {
                List = db.客戶聯絡人.Where(x => x.客戶Id == id);
            }

            return View(List.ToList());
        }

        // GET: 客戶聯絡人/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Dtl = db.客戶聯絡人.Find(id);
            if (Dtl == null) {
                return HttpNotFound();
            }
            return View(Dtl);
        }

        // GET: 客戶聯絡人/Create
        public ActionResult Create(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.CusID = id;
            return View();
        }

        // POST: 客戶聯絡人/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                客戶聯絡人 cnta = new 客戶聯絡人();
                cnta.客戶Id = int.Parse(collection["客戶Id"]);
                cnta.職稱 = collection["職稱"];
                cnta.姓名 = collection["姓名"];
                cnta.Email = collection["Email"];
                cnta.手機 = collection["手機"];
                cnta.電話 = collection["電話"];

                db.客戶聯絡人.Add(cnta);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: 客戶聯絡人/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 cnta = new 客戶聯絡人();
            cnta = db.客戶聯絡人.Find(id);
            if (cnta == null) {
                return HttpNotFound();
            }
            ViewBag.CusID = cnta.客戶Id;
            return View(cnta);
        }

        // POST: 客戶聯絡人/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                客戶聯絡人 cnta = new 客戶聯絡人();
                cnta = db.客戶聯絡人.Find(id);
                cnta.客戶Id = int.Parse(collection["客戶Id"]);
                cnta.職稱 = collection["職稱"];
                cnta.姓名 = collection["姓名"];
                cnta.Email = collection["Email"];
                cnta.手機 = collection["手機"];
                cnta.電話 = collection["電話"];
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: 客戶聯絡人/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 cnta = new 客戶聯絡人();
            cnta = db.客戶聯絡人.Find(id);
            if (cnta == null) {
                return HttpNotFound();
            }
            db.客戶聯絡人.Remove(cnta);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
