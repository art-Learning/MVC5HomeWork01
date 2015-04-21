using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5HomeWork01.Models;


namespace MVC5HomeWork01.Controllers
{
    public class 客戶資料Controller : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();

        // GET: 客戶資料
        public ActionResult Index()
        {
            var CustomerList = db.客戶資料;
            return View(CustomerList.ToList());
        }

        // GET: 客戶資料/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var CustomerDetail = db.客戶資料.Find(id);
            if (CustomerDetail == null) {
                return HttpNotFound();
            }
            return View(CustomerDetail);
        }

        // GET: 客戶資料/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: 客戶資料/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                客戶資料 userinfo = new 客戶資料();
                userinfo.客戶名稱 = collection["客戶名稱"];
                userinfo.統一編號 = collection["統一編號"];
                userinfo.電話 = collection["電話"];
                userinfo.傳真 = collection["傳真"];
                userinfo.地址 = collection["地址"];
                userinfo.Email = collection["Email"];

                db.客戶資料.Add(userinfo);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: 客戶資料/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 userinfo = new 客戶資料();
            userinfo = db.客戶資料.Find(id);
            if (userinfo == null) {
                return HttpNotFound();
            }
            return View(userinfo);
        }

        // POST: 客戶資料/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                客戶資料 userinfo = new 客戶資料();
                userinfo = db.客戶資料.Find(id);
                userinfo.客戶名稱 = collection["客戶名稱"];
                userinfo.統一編號 = collection["統一編號"];
                userinfo.電話 = collection["電話"];
                userinfo.傳真 = collection["傳真"];
                userinfo.地址 = collection["地址"];
                userinfo.Email = collection["Email"];
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: 客戶資料/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 userinfo = new 客戶資料();
            userinfo = db.客戶資料.Find(id);
            if (userinfo == null) {
                return HttpNotFound();
            }
            db.客戶資料.Remove(userinfo);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
