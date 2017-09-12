using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComputerParts.Models;

namespace ComputerParts.Controllers
{
    public class CPUsController : Controller
    {
        private PCPartsEntities1 db = new PCPartsEntities1();

        // GET: CPUs
        public ActionResult Index()
        {
            return View(db.CPUs.ToList());
        }

        // GET: CPUs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CPU cPU = db.CPUs.Find(id);
            if (cPU == null)
            {
                return HttpNotFound();
            }
            return View(cPU);
        }

        // GET: CPUs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CPUs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CPUId,Image,Name,Information,Price")] CPU cPU)
        {
            if (ModelState.IsValid)
            {
                db.CPUs.Add(cPU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cPU);
        }

        // GET: CPUs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CPU cPU = db.CPUs.Find(id);
            if (cPU == null)
            {
                return HttpNotFound();
            }
            return View(cPU);
        }

        // POST: CPUs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CPUId,Image,Name,Information,Price")] CPU cPU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cPU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cPU);
        }

        // GET: CPUs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CPU cPU = db.CPUs.Find(id);
            if (cPU == null)
            {
                return HttpNotFound();
            }
            return View(cPU);
        }

        // POST: CPUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CPU cPU = db.CPUs.Find(id);
            db.CPUs.Remove(cPU);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
