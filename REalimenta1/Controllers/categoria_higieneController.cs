using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using REalimenta1.Models;

namespace REalimenta1.Controllers
{
    public class categoria_higieneController : Controller
    {
        private bd_realimentaEntities db = new bd_realimentaEntities();

        // GET: categoria_higiene
        public ActionResult Index()
        {
            return View(db.categoria_higiene.ToList());
        }

        // GET: categoria_higiene/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categoria_higiene categoria_higiene = db.categoria_higiene.Find(id);
            if (categoria_higiene == null)
            {
                return HttpNotFound();
            }
            return View(categoria_higiene);
        }

        // GET: categoria_higiene/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: categoria_higiene/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "categoriahigiene_id,nome")] categoria_higiene categoria_higiene)
        {
            if (ModelState.IsValid)
            {
                db.categoria_higiene.Add(categoria_higiene);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoria_higiene);
        }

        // GET: categoria_higiene/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categoria_higiene categoria_higiene = db.categoria_higiene.Find(id);
            if (categoria_higiene == null)
            {
                return HttpNotFound();
            }
            return View(categoria_higiene);
        }

        // POST: categoria_higiene/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "categoriahigiene_id,nome")] categoria_higiene categoria_higiene)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoria_higiene).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria_higiene);
        }

        // GET: categoria_higiene/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categoria_higiene categoria_higiene = db.categoria_higiene.Find(id);
            if (categoria_higiene == null)
            {
                return HttpNotFound();
            }
            return View(categoria_higiene);
        }

        // POST: categoria_higiene/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            categoria_higiene categoria_higiene = db.categoria_higiene.Find(id);
            db.categoria_higiene.Remove(categoria_higiene);
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
