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
    public class Ver_SolicitudesController : Controller
    {
        private MODIFICACION_PRESUPUESTOEntities db = new MODIFICACION_PRESUPUESTOEntities();

        // GET: Ver_Solicitudes
        public ActionResult Index()
        {
            return View(db.Ver_Solicitudes.ToList());
        }

        // GET: Ver_Solicitudes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ver_Solicitudes ver_Solicitudes = db.Ver_Solicitudes.Find(id);
            if (ver_Solicitudes == null)
            {
                return HttpNotFound();
            }
            return View(ver_Solicitudes);
        }

        // GET: Ver_Solicitudes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ver_Solicitudes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Tipo,Solicitante,Periodo,Depto_Origen,Codigo_PartidaOrigen,Partida_Origen,Depto_Destino,Codigo_PartidaDestino,Partida_Destino,Monto,Fecha_Solicitud,Fecha_Respuesta,Estado_Solicitud")] Ver_Solicitudes ver_Solicitudes)
        {
            if (ModelState.IsValid)
            {
                db.Ver_Solicitudes.Add(ver_Solicitudes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ver_Solicitudes);
        }

        // GET: Ver_Solicitudes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ver_Solicitudes ver_Solicitudes = db.Ver_Solicitudes.Find(id);
            if (ver_Solicitudes == null)
            {
                return HttpNotFound();
            }
            return View(ver_Solicitudes);
        }

        // POST: Ver_Solicitudes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Tipo,Solicitante,Periodo,Depto_Origen,Codigo_PartidaOrigen,Partida_Origen,Depto_Destino,Codigo_PartidaDestino,Partida_Destino,Monto,Fecha_Solicitud,Fecha_Respuesta,Estado_Solicitud")] Ver_Solicitudes ver_Solicitudes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ver_Solicitudes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ver_Solicitudes);
        }

        // GET: Ver_Solicitudes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ver_Solicitudes ver_Solicitudes = db.Ver_Solicitudes.Find(id);
            if (ver_Solicitudes == null)
            {
                return HttpNotFound();
            }
            return View(ver_Solicitudes);
        }

        // POST: Ver_Solicitudes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ver_Solicitudes ver_Solicitudes = db.Ver_Solicitudes.Find(id);
            db.Ver_Solicitudes.Remove(ver_Solicitudes);
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
