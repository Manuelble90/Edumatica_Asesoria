using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sistema02_MVC.Models;

namespace Sistema02_MVC.Controllers
{
    public class deparmentsController : Controller
    {
        private edumatica_dbEntities db = new edumatica_dbEntities();

        // GET: deparments
        public ActionResult Index()
        {
            return View(db.deparment.ToList());
        }

        // GET: deparments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            deparment deparment = db.deparment.Find(id);
            if (deparment == null)
            {
                return HttpNotFound();
            }
            return View(deparment);
        }

        // GET: deparments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: deparments/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descripcion")] deparment deparment)
        {
            if (ModelState.IsValid)
            {
                db.deparment.Add(deparment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deparment);
        }

        // GET: deparments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            deparment deparment = db.deparment.Find(id);
            if (deparment == null)
            {
                return HttpNotFound();
            }
            return View(deparment);
        }

        // POST: deparments/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion")] deparment deparment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deparment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deparment);
        }

        // GET: deparments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            deparment deparment = db.deparment.Find(id);
            if (deparment == null)
            {
                return HttpNotFound();
            }
            return View(deparment);
        }

        // POST: deparments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            deparment deparment = db.deparment.Find(id);
            db.deparment.Remove(deparment);
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
