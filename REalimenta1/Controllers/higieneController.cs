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
    public class higieneController : Controller
    {
        private bd_realimentaEntities db = new bd_realimentaEntities();

        // GET: higiene
        public ActionResult Index()
        {
            var higiene = db.higiene.Include(h => h.categoria_higiene).Include(h => h.mercado);
            return View(higiene.ToList());
        }

        // GET: higiene/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            higiene higiene = db.higiene.Find(id);
            if (higiene == null)
            {
                return HttpNotFound();
            }
            return View(higiene);
        }

        // GET: higiene/Create
        public ActionResult Create()
        {
            ViewBag.categoriahigiene_id = new SelectList(db.categoria_higiene, "categoriahigiene_id", "nome");
            ViewBag.mercado_id = new SelectList(db.mercado, "mercado_id", "cnpj");
            return View();
        }

        // POST: higiene/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "higiene_id,validade,quantidade,nome,detalhes,origem,mercado_id,categoriahigiene_id")] higiene higiene)
        {
            if (ModelState.IsValid)
            {
                db.higiene.Add(higiene);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoriahigiene_id = new SelectList(db.categoria_higiene, "categoriahigiene_id", "nome", higiene.categoriahigiene_id);
            ViewBag.mercado_id = new SelectList(db.mercado, "mercado_id", "cnpj", higiene.mercado_id);
            return View(higiene);
        }

        // GET: higiene/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            higiene higiene = db.higiene.Find(id);
            if (higiene == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoriahigiene_id = new SelectList(db.categoria_higiene, "categoriahigiene_id", "nome", higiene.categoriahigiene_id);
            ViewBag.mercado_id = new SelectList(db.mercado, "mercado_id", "cnpj", higiene.mercado_id);
            return View(higiene);
        }

        // POST: higiene/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "higiene_id,validade,quantidade,nome,detalhes,origem,mercado_id,categoriahigiene_id")] higiene higiene)
        {
            if (ModelState.IsValid)
            {
                db.Entry(higiene).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoriahigiene_id = new SelectList(db.categoria_higiene, "categoriahigiene_id", "nome", higiene.categoriahigiene_id);
            ViewBag.mercado_id = new SelectList(db.mercado, "mercado_id", "cnpj", higiene.mercado_id);
            return View(higiene);
        }

        // GET: higiene/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            higiene higiene = db.higiene.Find(id);
            if (higiene == null)
            {
                return HttpNotFound();
            }
            return View(higiene);
        }

        // POST: higiene/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            higiene higiene = db.higiene.Find(id);
            db.higiene.Remove(higiene);
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
