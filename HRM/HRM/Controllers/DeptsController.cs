using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRM.Models;

namespace HRM.Controllers
{
    public class DeptsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Depts
        public ActionResult Index()
        {
            var depts = db.Depts.Include(d => d.Division);
            return View(depts.ToList());
        }

        // GET: Depts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dept dept = db.Depts.Find(id);
            if (dept == null)
            {
                return HttpNotFound();
            }
            return View(dept);
        }

        // GET: Depts/Create
        public ActionResult Create()
        {
            ViewBag.DivisionId = new SelectList(db.Divisions, "Id", "DivisionCode");
            return View();
        }

        // POST: Depts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DeptCode,DeptName,DivisionId")] Dept dept)
        {
            if (ModelState.IsValid)
            {
                db.Depts.Add(dept);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DivisionId = new SelectList(db.Divisions, "Id", "DivisionCode", dept.DivisionId);
            return View(dept);
        }

        // GET: Depts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dept dept = db.Depts.Find(id);
            if (dept == null)
            {
                return HttpNotFound();
            }
            ViewBag.DivisionId = new SelectList(db.Divisions, "Id", "DivisionCode", dept.DivisionId);
            return View(dept);
        }

        // POST: Depts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DeptCode,DeptName,DivisionId")] Dept dept)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dept).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DivisionId = new SelectList(db.Divisions, "Id", "DivisionCode", dept.DivisionId);
            return View(dept);
        }

        // GET: Depts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dept dept = db.Depts.Find(id);
            if (dept == null)
            {
                return HttpNotFound();
            }
            return View(dept);
        }

        // POST: Depts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dept dept = db.Depts.Find(id);
            db.Depts.Remove(dept);
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
