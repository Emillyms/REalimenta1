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
    public class categoria_alimentoController : Controller
    {
        private bd_realimentaEntities db = new bd_realimentaEntities();

        // GET: categoria_alimento
        public ActionResult Index()
        {
            return View(db.categoria_alimento.ToList());
        }

        // GET: categoria_alimento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categoria_alimento categoria_alimento = db.categoria_alimento.Find(id);
            if (categoria_alimento == null)
            {
                return HttpNotFound();
            }
            return View(categoria_alimento);
        }

        // GET: categoria_alimento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: categoria_alimento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "categoriaalimento_id,nome")] categoria_alimento categoria_alimento)
        {
            if (ModelState.IsValid)
            {
                db.categoria_alimento.Add(categoria_alimento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoria_alimento);
        }

        // GET: categoria_alimento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categoria_alimento categoria_alimento = db.categoria_alimento.Find(id);
            if (categoria_alimento == null)
            {
                return HttpNotFound();
            }
            return View(categoria_alimento);
        }

        // POST: categoria_alimento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "categoriaalimento_id,nome")] categoria_alimento categoria_alimento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoria_alimento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria_alimento);
        }

        // GET: categoria_alimento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categoria_alimento categoria_alimento = db.categoria_alimento.Find(id);
            if (categoria_alimento == null)
            {
                return HttpNotFound();
            }
            return View(categoria_alimento);
        }

        // POST: categoria_alimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            categoria_alimento categoria_alimento = db.categoria_alimento.Find(id);
            db.categoria_alimento.Remove(categoria_alimento);
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
