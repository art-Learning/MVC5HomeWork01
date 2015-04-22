using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5HomeWork01.Models;

namespace MVC5HomeWork01.Controllers
{
    public class 客戶銀行資訊Controller : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();

        // GET: 客戶銀行資訊
        public ActionResult Index(int? id)
        {
            IQueryable<客戶銀行資訊> bankInfo;
            if (id == null) {
                bankInfo = db.客戶銀行資訊;
            } else {
                bankInfo = db.客戶銀行資訊.Where(x => x.客戶Id == id);
            }

            return View(bankInfo.ToList());
        }

        // GET: 客戶銀行資訊/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var dtl = db.客戶銀行資訊.Find(id);
            if (dtl == null) {
                return HttpNotFound();
            }
            return View(dtl);
        }

        // GET: 客戶銀行資訊/Create
        public ActionResult Create(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.CusID = id;
            return View();
        }

        // POST: 客戶銀行資訊/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                客戶銀行資訊 binfo = new 客戶銀行資訊();
                binfo.客戶Id = int.Parse(collection["客戶Id"]);
                binfo.銀行名稱 = collection["銀行名稱"];
                binfo.銀行代碼 = int.Parse(collection["銀行代碼"]);
                binfo.分行代碼 = int.Parse(collection["分行代碼"]);
                binfo.帳戶名稱 = collection["帳戶名稱"];
                binfo.帳戶號碼 = collection["帳戶號碼"];
                db.客戶銀行資訊.Add(binfo);
                db.SaveChanges();

                return RedirectToAction("Index","客戶銀行資訊",new {id=binfo.客戶Id});
                
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: 客戶銀行資訊/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 binfo = new 客戶銀行資訊();
            binfo = db.客戶銀行資訊.Find(id);
            if (binfo == null) {
                return HttpNotFound();
            }
            ViewBag.CusID = binfo.客戶Id;
            return View(binfo);
        }

        // POST: 客戶銀行資訊/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                客戶銀行資訊 binfo = new 客戶銀行資訊();
                binfo = db.客戶銀行資訊.Find(id);
                binfo.銀行名稱 = collection["銀行名稱"];
                binfo.銀行代碼 = int.Parse(collection["銀行代碼"]);
                binfo.分行代碼 = int.Parse(collection["分行代碼"]);
                binfo.帳戶名稱 = collection["帳戶名稱"];
                binfo.帳戶號碼 = collection["帳戶號碼"];
                db.SaveChanges();
                return RedirectToAction("Details", "客戶銀行資訊", new { id=binfo.Id});
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: 客戶銀行資訊/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 binfo = new 客戶銀行資訊();
            binfo = db.客戶銀行資訊.Find(id);
            if (binfo == null) {
                return HttpNotFound();
            }
            db.客戶銀行資訊.Remove(binfo);
            db.SaveChanges();

            //TODO 刪除資料後，需判斷如果還有該公司資料，則返回列表頁；否則返回公司明細頁
            return RedirectToAction("Index", "客戶銀行資訊", new { id=binfo.客戶Id});
        }


    }
}
