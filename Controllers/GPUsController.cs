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
    public class GPUsController : Controller
    {
        private PCPartsEntities1 db = new PCPartsEntities1();

        // GET: GPUs
        public ActionResult Index()
        {
            return View(db.GPUs.ToList());
        }

        // GET: GPUs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GPU gPU = db.GPUs.Find(id);
            if (gPU == null)
            {
                return HttpNotFound();
            }
            return View(gPU);
        }

        // GET: GPUs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GPUs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GPUId,Image,Name,Information,Price")] GPU gPU)
        {
            if (ModelState.IsValid)
            {
                db.GPUs.Add(gPU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gPU);
        }

        // GET: GPUs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GPU gPU = db.GPUs.Find(id);
            if (gPU == null)
            {
                return HttpNotFound();
            }
            return View(gPU);
        }

        // POST: GPUs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GPUId,Image,Name,Information,Price")] GPU gPU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gPU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gPU);
        }

        // GET: GPUs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GPU gPU = db.GPUs.Find(id);
            if (gPU == null)
            {
                return HttpNotFound();
            }
            return View(gPU);
        }

        // POST: GPUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GPU gPU = db.GPUs.Find(id);
            db.GPUs.Remove(gPU);
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
