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
    public class Ver_HistoricoController : Controller
    {
        private MODIFICACION_PRESUPUESTOEntities db = new MODIFICACION_PRESUPUESTOEntities();

        // GET: Ver_Historico
        public ActionResult Index()
        {
            return View(db.Ver_Historico.ToList());
        }

        // GET: Ver_Historico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ver_Historico ver_Historico = db.Ver_Historico.Find(id);
            if (ver_Historico == null)
            {
                return HttpNotFound();
            }
            return View(ver_Historico);
        }

        // GET: Ver_Historico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ver_Historico/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Periodo,Solicitud,Tipo,Fecha_Solicitud,Fecha_Respuesta,Depto_Origen,Cod_Partida,Partida_Origen,Saldo_Inicial,Monto_Solicitud,Nuevo_Saldo,Depto_Destino,Cod_Partida_Destino,Partida_Destino,Saldo_Inicial_Destino,Monto__Solicitud,Nuevo_Saldo_Destino,Solicitante,Analista_Responsable,Estado_Solicitud")] Ver_Historico ver_Historico)
        {
            if (ModelState.IsValid)
            {
                db.Ver_Historico.Add(ver_Historico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ver_Historico);
        }

        // GET: Ver_Historico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ver_Historico ver_Historico = db.Ver_Historico.Find(id);
            if (ver_Historico == null)
            {
                return HttpNotFound();
            }
            return View(ver_Historico);
        }

        // POST: Ver_Historico/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Periodo,Solicitud,Tipo,Fecha_Solicitud,Fecha_Respuesta,Depto_Origen,Cod_Partida,Partida_Origen,Saldo_Inicial,Monto_Solicitud,Nuevo_Saldo,Depto_Destino,Cod_Partida_Destino,Partida_Destino,Saldo_Inicial_Destino,Monto__Solicitud,Nuevo_Saldo_Destino,Solicitante,Analista_Responsable,Estado_Solicitud")] Ver_Historico ver_Historico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ver_Historico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ver_Historico);
        }

        // GET: Ver_Historico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ver_Historico ver_Historico = db.Ver_Historico.Find(id);
            if (ver_Historico == null)
            {
                return HttpNotFound();
            }
            return View(ver_Historico);
        }

        // POST: Ver_Historico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ver_Historico ver_Historico = db.Ver_Historico.Find(id);
            db.Ver_Historico.Remove(ver_Historico);
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
