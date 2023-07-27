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
    public class Ver_Partidas_AsignadasController : Controller
    {
        private MODIFICACION_PRESUPUESTOEntities db = new MODIFICACION_PRESUPUESTOEntities();

        // GET: Ver_Partidas_Asignadas
        public ActionResult Index()
        {
            return View(db.Ver_Partidas_Asignadas.ToList());
        }

        // GET: Ver_Partidas_Asignadas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ver_Partidas_Asignadas ver_Partidas_Asignadas = db.Ver_Partidas_Asignadas.Find(id);
            if (ver_Partidas_Asignadas == null)
            {
                return HttpNotFound();
            }
            return View(ver_Partidas_Asignadas);
        }

        // GET: Ver_Partidas_Asignadas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ver_Partidas_Asignadas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDepto,Departamento,Cod,Partida,Monto_asignado")] Ver_Partidas_Asignadas ver_Partidas_Asignadas)
        {
            if (ModelState.IsValid)
            {
                db.Ver_Partidas_Asignadas.Add(ver_Partidas_Asignadas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ver_Partidas_Asignadas);
        }

        // GET: Ver_Partidas_Asignadas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ver_Partidas_Asignadas ver_Partidas_Asignadas = db.Ver_Partidas_Asignadas.Find(id);
            if (ver_Partidas_Asignadas == null)
            {
                return HttpNotFound();
            }
            return View(ver_Partidas_Asignadas);
        }

        // POST: Ver_Partidas_Asignadas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDepto,Departamento,Cod,Partida,Monto_asignado")] Ver_Partidas_Asignadas ver_Partidas_Asignadas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ver_Partidas_Asignadas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ver_Partidas_Asignadas);
        }

        // GET: Ver_Partidas_Asignadas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ver_Partidas_Asignadas ver_Partidas_Asignadas = db.Ver_Partidas_Asignadas.Find(id);
            if (ver_Partidas_Asignadas == null)
            {
                return HttpNotFound();
            }
            return View(ver_Partidas_Asignadas);
        }

        // POST: Ver_Partidas_Asignadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ver_Partidas_Asignadas ver_Partidas_Asignadas = db.Ver_Partidas_Asignadas.Find(id);
            db.Ver_Partidas_Asignadas.Remove(ver_Partidas_Asignadas);
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
