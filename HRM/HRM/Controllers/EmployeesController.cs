using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRM.Models;
using System.IO;

namespace HRM.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Dept).Include(e => e.Designation);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.DeptId = new SelectList(db.Depts, "Id", "DeptCode");
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "ShortName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeCode,FullName,NickName,MobileNumber,Email,FatherName,MotherName,DesignationId,BloodGroup,DeptId,Address,EmployeePhotoPath, EmployeePhoto")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                //For saving photo
                if (employee.EmployeePhoto != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(employee.EmployeePhoto.FileName);
                    string extension = Path.GetExtension(employee.EmployeePhoto.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    employee.EmployeePhotoPath = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    employee.EmployeePhoto.SaveAs(fileName);
                }

                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeptId = new SelectList(db.Depts, "Id", "DeptCode", employee.DeptId);
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "ShortName", employee.DesignationId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeptId = new SelectList(db.Depts, "Id", "DeptCode", employee.DeptId);
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "ShortName", employee.DesignationId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeCode,FullName,NickName,MobileNumber,Email,FatherName,MotherName,DesignationId,BloodGroup,DeptId,Address,EmployeePhotoPath, EmployeePhoto")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;

                //For editing photo
                if (employee.EmployeePhoto != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(employee.EmployeePhoto.FileName);
                    string extension = Path.GetExtension(employee.EmployeePhoto.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    employee.EmployeePhotoPath = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    employee.EmployeePhoto.SaveAs(fileName);
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeptId = new SelectList(db.Depts, "Id", "DeptCode", employee.DeptId);
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "ShortName", employee.DesignationId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
