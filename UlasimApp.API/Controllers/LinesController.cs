﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UlasimApp.API.Models;

namespace UlasimApp.API.Controllers
{
    public class LinesController : Controller
    {
        private UlasimAppAPIContext db = new UlasimAppAPIContext();


        public ActionResult GetLineStops(int id)
        {
            var res = db.Stops.Where(s => s.LineId == id).ToList();
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        // GET: Lines
        public ActionResult Index()
        {
            return View(db.Lines.ToList());
        }

        // GET: Lines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Line line = db.Lines.Find(id);
            if (line == null)
            {
                return HttpNotFound();
            }

            return Json(line, JsonRequestBehavior.AllowGet);

        }

        // GET: Lines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FromId,From,To")] Line line)
        {
            if (ModelState.IsValid)
            {
                db.Lines.Add(line);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(line);
        }

        // GET: Lines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Line line = db.Lines.Find(id);
            if (line == null)
            {
                return HttpNotFound();
            }
            return View(line);
        }

        // POST: Lines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FromId,From,To")] Line line)
        {
            if (ModelState.IsValid)
            {
                db.Entry(line).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(line);
        }

        // GET: Lines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Line line = db.Lines.Find(id);
            if (line == null)
            {
                return HttpNotFound();
            }
            return View(line);
        }

        // POST: Lines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Line line = db.Lines.Find(id);
            db.Lines.Remove(line);
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
