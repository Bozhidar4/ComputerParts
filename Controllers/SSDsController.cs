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
    public class SSDsController : Controller
    {
        private PCPartsEntities1 db = new PCPartsEntities1();

        // GET: SSDs
        public ActionResult Index()
        {
            return View(db.SSDs.ToList());
        }

        // GET: SSDs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SSD sSD = db.SSDs.Find(id);
            if (sSD == null)
            {
                return HttpNotFound();
            }
            return View(sSD);
        }

        // GET: SSDs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SSDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SSDId,Image,Name,Information,Price")] SSD sSD)
        {
            if (ModelState.IsValid)
            {
                db.SSDs.Add(sSD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sSD);
        }

        // GET: SSDs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SSD sSD = db.SSDs.Find(id);
            if (sSD == null)
            {
                return HttpNotFound();
            }
            return View(sSD);
        }

        // POST: SSDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SSDId,Image,Name,Information,Price")] SSD sSD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sSD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sSD);
        }

        // GET: SSDs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SSD sSD = db.SSDs.Find(id);
            if (sSD == null)
            {
                return HttpNotFound();
            }
            return View(sSD);
        }

        // POST: SSDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SSD sSD = db.SSDs.Find(id);
            db.SSDs.Remove(sSD);
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
