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
    public class doacaoController : Controller
    {
        private bd_realimentaEntities db = new bd_realimentaEntities();

        // GET: doacao
        public ActionResult Index()
        {
            var doacao = db.doacao.Include(d => d.categoria_alimento).Include(d => d.mercado);
            return View(doacao.ToList());
        }

        // GET: doacao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doacao doacao = db.doacao.Find(id);
            if (doacao == null)
            {
                return HttpNotFound();
            }
            return View(doacao);
        }

        // GET: doacao/Create
        public ActionResult Create()
        {
            ViewBag.alimento_id = new SelectList(db.categoria_alimento, "categoriaalimento_id", "nome");
            ViewBag.mercado_id = new SelectList(db.mercado, "mercado_id", "cnpj");
            return View();
        }

        // POST: doacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "doacao_id,ong_id,mercado_id,alimento_id,higiene_id")] doacao doacao)
        {
            if (ModelState.IsValid)
            {
                db.doacao.Add(doacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.alimento_id = new SelectList(db.categoria_alimento, "categoriaalimento_id", "nome", doacao.alimento_id);
            ViewBag.mercado_id = new SelectList(db.mercado, "mercado_id", "cnpj", doacao.mercado_id);
            return View(doacao);
        }

        // GET: doacao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doacao doacao = db.doacao.Find(id);
            if (doacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.alimento_id = new SelectList(db.categoria_alimento, "categoriaalimento_id", "nome", doacao.alimento_id);
            ViewBag.mercado_id = new SelectList(db.mercado, "mercado_id", "cnpj", doacao.mercado_id);
            return View(doacao);
        }

        // POST: doacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "doacao_id,ong_id,mercado_id,alimento_id,higiene_id")] doacao doacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.alimento_id = new SelectList(db.categoria_alimento, "categoriaalimento_id", "nome", doacao.alimento_id);
            ViewBag.mercado_id = new SelectList(db.mercado, "mercado_id", "cnpj", doacao.mercado_id);
            return View(doacao);
        }

        // GET: doacao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doacao doacao = db.doacao.Find(id);
            if (doacao == null)
            {
                return HttpNotFound();
            }
            return View(doacao);
        }

        // POST: doacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            doacao doacao = db.doacao.Find(id);
            db.doacao.Remove(doacao);
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

        public ActionResult How()
        {
            return View();
        }
    }
}
