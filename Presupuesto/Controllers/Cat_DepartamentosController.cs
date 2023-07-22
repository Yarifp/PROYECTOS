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
    public class Cat_DepartamentosController : Controller
    {
        private MODIFICACION_PRESUPUESTOEntities db = new MODIFICACION_PRESUPUESTOEntities();

        // GET: Cat_Departamentos
        public ActionResult Index()
        {
            return View(db.Cat_Departamentos.ToList());
        }

        // GET: Cat_Departamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cat_Departamentos cat_Departamentos = db.Cat_Departamentos.Find(id);
            if (cat_Departamentos == null)
            {
                return HttpNotFound();
            }
            return View(cat_Departamentos);
        }

        // GET: Cat_Departamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cat_Departamentos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDepto,Nombre,Presupuesto_autorizado,Presupuesto_asignado")] Cat_Departamentos cat_Departamentos)
        {
            if (ModelState.IsValid)
            {
                db.Cat_Departamentos.Add(cat_Departamentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cat_Departamentos);
        }

        // GET: Cat_Departamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cat_Departamentos cat_Departamentos = db.Cat_Departamentos.Find(id);
            if (cat_Departamentos == null)
            {
                return HttpNotFound();
            }
            return View(cat_Departamentos);
        }

        // POST: Cat_Departamentos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDepto,Nombre,Presupuesto_autorizado,Presupuesto_asignado")] Cat_Departamentos cat_Departamentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cat_Departamentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cat_Departamentos);
        }

        // GET: Cat_Departamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cat_Departamentos cat_Departamentos = db.Cat_Departamentos.Find(id);
            if (cat_Departamentos == null)
            {
                return HttpNotFound();
            }
            return View(cat_Departamentos);
        }

        // POST: Cat_Departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cat_Departamentos cat_Departamentos = db.Cat_Departamentos.Find(id);
            db.Cat_Departamentos.Remove(cat_Departamentos);
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
