using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5HomeWork01.Controllers
{
    public class 客戶聯絡人Controller : Controller
    {
        // GET: 客戶聯絡人
        public ActionResult Index()
        {
            return View();
        }

        // GET: 客戶聯絡人/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: 客戶聯絡人/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: 客戶聯絡人/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: 客戶聯絡人/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: 客戶聯絡人/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: 客戶聯絡人/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: 客戶聯絡人/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
