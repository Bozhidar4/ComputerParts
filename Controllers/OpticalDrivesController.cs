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
    public class OpticalDrivesController : Controller
    {
        private PCPartsEntities1 db = new PCPartsEntities1();

        // GET: OpticalDrives
        public ActionResult Index()
        {
            return View(db.OpticalDrives.ToList());
        }

        // GET: OpticalDrives/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpticalDrive opticalDrive = db.OpticalDrives.Find(id);
            if (opticalDrive == null)
            {
                return HttpNotFound();
            }
            return View(opticalDrive);
        }

        // GET: OpticalDrives/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OpticalDrives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OpticalDriveId,Image,Name,Information,Price")] OpticalDrive opticalDrive)
        {
            if (ModelState.IsValid)
            {
                db.OpticalDrives.Add(opticalDrive);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(opticalDrive);
        }

        // GET: OpticalDrives/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpticalDrive opticalDrive = db.OpticalDrives.Find(id);
            if (opticalDrive == null)
            {
                return HttpNotFound();
            }
            return View(opticalDrive);
        }

        // POST: OpticalDrives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OpticalDriveId,Image,Name,Information,Price")] OpticalDrive opticalDrive)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opticalDrive).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(opticalDrive);
        }

        // GET: OpticalDrives/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpticalDrive opticalDrive = db.OpticalDrives.Find(id);
            if (opticalDrive == null)
            {
                return HttpNotFound();
            }
            return View(opticalDrive);
        }

        // POST: OpticalDrives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OpticalDrive opticalDrive = db.OpticalDrives.Find(id);
            db.OpticalDrives.Remove(opticalDrive);
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
