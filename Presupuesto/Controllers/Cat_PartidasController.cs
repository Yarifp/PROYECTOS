using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Presupuesto;

namespace Presupuesto.Controllers
{
    public class Cat_PartidasController : Controller
    {
        private MODIFICACION_PRESUPUESTOEntities db = new MODIFICACION_PRESUPUESTOEntities();

        // GET: Cat_Partidas
        public ActionResult Index()
        {
            return View(db.Cat_Partidas.ToList());
        }

        // GET: Cat_Partidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cat_Partidas cat_Partidas = db.Cat_Partidas.Find(id);
            if (cat_Partidas == null)
            {
                return HttpNotFound();
            }
            return View(cat_Partidas);
        }

        // GET: Cat_Partidas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cat_Partidas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPartida,Codigo,Nombre")] Cat_Partidas cat_Partidas)
        {
            if (ModelState.IsValid)
            {
                db.Cat_Partidas.Add(cat_Partidas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cat_Partidas);
        }

        // GET: Cat_Partidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cat_Partidas cat_Partidas = db.Cat_Partidas.Find(id);
            if (cat_Partidas == null)
            {
                return HttpNotFound();
            }
            return View(cat_Partidas);
        }

        // POST: Cat_Partidas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPartida,Codigo,Nombre")] Cat_Partidas cat_Partidas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cat_Partidas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cat_Partidas);
        }

        // GET: Cat_Partidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cat_Partidas cat_Partidas = db.Cat_Partidas.Find(id);
            if (cat_Partidas == null)
            {
                return HttpNotFound();
            }
            return View(cat_Partidas);
        }

        // POST: Cat_Partidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cat_Partidas cat_Partidas = db.Cat_Partidas.Find(id);
            db.Cat_Partidas.Remove(cat_Partidas);
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
