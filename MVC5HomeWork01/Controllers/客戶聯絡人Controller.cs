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
            //TODO 篩選條件需增加：取得未作廢的資料
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

                return RedirectToAction("Index", "客戶聯絡人", new { id = collection["客戶Id"] });
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
                return RedirectToAction("Details", "客戶聯絡人", new { id = id });
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: 客戶聯絡人/Delete/5
        public ActionResult Delete(int? id)
        {
            //TODO 刪除發生錯誤，須修正，一併刪除關聯的資料表資料(客戶聯絡人、客戶銀行資訊)
            //TODO 增加作廢欄位，刪除改為使用作廢，前台不顯示。

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

            //TODO 刪除聯絡人後，導向頁面需重新確認
            return RedirectToAction("index");
        }

    }
}
