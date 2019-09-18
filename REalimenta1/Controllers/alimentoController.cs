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
    public class alimentoController : Controller
    {
        private bd_realimentaEntities db = new bd_realimentaEntities();

        // GET: alimento
        public ActionResult Index()
        {
            var alimento = db.alimento.Include(a => a.categoria_alimento).Include(a => a.mercado);
            return View(alimento.ToList());
        }

        // GET: alimento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alimento alimento = db.alimento.Find(id);
            if (alimento == null)
            {
                return HttpNotFound();
            }
            return View(alimento);
        }

        // GET: alimento/Create
        public ActionResult Create()
        {
            ViewBag.categoriaalimento_id = new SelectList(db.categoria_alimento, "categoriaalimento_id", "nome");
            ViewBag.mercado_id = new SelectList(db.mercado, "mercado_id", "cnpj");
            return View();
        }

        // POST: alimento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "alimento_id,validade,quantidade,nome,detalhes,origem,mercado_id,categoriaalimento_id")] alimento alimento)
        {
            if (ModelState.IsValid)
            {
                db.alimento.Add(alimento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoriaalimento_id = new SelectList(db.categoria_alimento, "categoriaalimento_id", "nome", alimento.categoriaalimento_id);
            ViewBag.mercado_id = new SelectList(db.mercado, "mercado_id", "cnpj", alimento.mercado_id);
            return View(alimento);
        }

        // GET: alimento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alimento alimento = db.alimento.Find(id);
            if (alimento == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoriaalimento_id = new SelectList(db.categoria_alimento, "categoriaalimento_id", "nome", alimento.categoriaalimento_id);
            ViewBag.mercado_id = new SelectList(db.mercado, "mercado_id", "cnpj", alimento.mercado_id);
            return View(alimento);
        }

        // POST: alimento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "alimento_id,validade,quantidade,nome,detalhes,origem,mercado_id,categoriaalimento_id")] alimento alimento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alimento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoriaalimento_id = new SelectList(db.categoria_alimento, "categoriaalimento_id", "nome", alimento.categoriaalimento_id);
            ViewBag.mercado_id = new SelectList(db.mercado, "mercado_id", "cnpj", alimento.mercado_id);
            return View(alimento);
        }

        // GET: alimento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alimento alimento = db.alimento.Find(id);
            if (alimento == null)
            {
                return HttpNotFound();
            }
            return View(alimento);
        }

        // POST: alimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            alimento alimento = db.alimento.Find(id);
            db.alimento.Remove(alimento);
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
