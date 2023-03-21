using PracticingMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PracticingMVC.Controllers
{
    public class HomeController : Controller
    {
        EmployeeContext db = new EmployeeContext(); 
        public ActionResult Index()
        {
            var data = db.employees.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if(ModelState.IsValid)
            {
                //employee.JoiningDate = DateTime.Now;
                db.employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        public ActionResult edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee = db.employees.SingleOrDefault(e => e.EmployeeId == id);
            if(employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if(ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee = db.employees.SingleOrDefault(e => e.EmployeeId==id);
            if(employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        [HttpPost]
        public ActionResult Delete (int id)
        {
            var employee = db.employees.SingleOrDefault(x => x.EmployeeId==id);
            db.employees.Remove(employee ?? throw new InvalidOperationException());
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}