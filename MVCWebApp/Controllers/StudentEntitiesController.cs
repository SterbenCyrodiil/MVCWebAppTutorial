using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCWebApp.DAL;
using MVCWebApp.Models;

namespace MVCWebApp.Controllers
{
    public class StudentEntitiesController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: StudentEntities
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: StudentEntities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentEntity studentEntity = db.Students.Find(id);
            if (studentEntity == null)
            {
                return HttpNotFound();
            }
            return View(studentEntity);
        }

        // GET: StudentEntities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LastName,FirstMidName,EnrollmentDate")] StudentEntity studentEntity)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(studentEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentEntity);
        }

        // GET: StudentEntities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentEntity studentEntity = db.Students.Find(id);
            if (studentEntity == null)
            {
                return HttpNotFound();
            }
            return View(studentEntity);
        }

        // POST: StudentEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LastName,FirstMidName,EnrollmentDate")] StudentEntity studentEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentEntity);
        }

        // GET: StudentEntities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentEntity studentEntity = db.Students.Find(id);
            if (studentEntity == null)
            {
                return HttpNotFound();
            }
            return View(studentEntity);
        }

        // POST: StudentEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentEntity studentEntity = db.Students.Find(id);
            db.Students.Remove(studentEntity);
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
