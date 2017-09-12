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
    public class HDDsController : Controller
    {
        private PCPartsEntities1 db = new PCPartsEntities1();

        // GET: HDDs
        public ActionResult Index()
        {
            return View(db.HDDs.ToList());
        }

        // GET: HDDs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HDD hDD = db.HDDs.Find(id);
            if (hDD == null)
            {
                return HttpNotFound();
            }
            return View(hDD);
        }

        // GET: HDDs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HDDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HDDId,Image,Name,Information,Price")] HDD hDD)
        {
            if (ModelState.IsValid)
            {
                db.HDDs.Add(hDD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hDD);
        }

        // GET: HDDs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HDD hDD = db.HDDs.Find(id);
            if (hDD == null)
            {
                return HttpNotFound();
            }
            return View(hDD);
        }

        // POST: HDDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HDDId,Image,Name,Information,Price")] HDD hDD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hDD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hDD);
        }

        // GET: HDDs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HDD hDD = db.HDDs.Find(id);
            if (hDD == null)
            {
                return HttpNotFound();
            }
            return View(hDD);
        }

        // POST: HDDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HDD hDD = db.HDDs.Find(id);
            db.HDDs.Remove(hDD);
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
