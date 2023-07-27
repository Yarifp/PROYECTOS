using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Presupuesto;

namespace Presupuesto.Controllers
{
    public class SolicitudesController : Controller
    {
        private MODIFICACION_PRESUPUESTOEntities db = new MODIFICACION_PRESUPUESTOEntities();

        // GET: Solicitudes
        public ActionResult Index()
        {
            var solicitudes = db.Solicitudes.Include(s => s.Cat_Departamentos).Include(s => s.Cat_Departamentos1).Include(s => s.Cat_Estado_Solicitud).Include(s => s.Cat_Periodo_Modificaciones).Include(s => s.Cat_Solicitudes).Include(s => s.Empleados);
            return View(solicitudes.ToList());
        }

        // GET: Solicitudes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitudes solicitudes = db.Solicitudes.Find(id);
            if (solicitudes == null)
            {
                return HttpNotFound();
            }
            return View(solicitudes);
        }

        // GET: Solicitudes/Create
        public ActionResult Create()
        {
            ViewBag.idDepartamento_Origen = new SelectList(db.Cat_Departamentos, "idDepto", "Nombre");
            ViewBag.idDepartamento_Destino = new SelectList(db.Cat_Departamentos, "idDepto", "Nombre");
            ViewBag.idEstado = new SelectList(db.Cat_Estado_Solicitud, "idEstado", "Nombre");
            ViewBag.idPeriodo = new SelectList(db.Cat_Periodo_Modificaciones, "idPeriodo", "idPeriodo");
            ViewBag.idTipoSolicitud = new SelectList(db.Cat_Solicitudes, "idTipoSolicitud", "Nombre");
            ViewBag.idSolicitante = new SelectList(db.Empleados, "idEmpleado", "Nombre");
            return View();
        }

        // POST: Solicitudes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSolicitud,idTipoSolicitud,idSolicitante,idPeriodo,idDepartamento_Origen,CodPartida_Origen,idDepartamento_Destino,CodPartida_Destino,Monto_Solicitado,Fecha_Solicitud,Fecha_Respuesta,idEstado")] Solicitudes solicitudes)
        {
            if (ModelState.IsValid)
            {
                db.Solicitudes.Add(solicitudes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idDepartamento_Origen = new SelectList(db.Cat_Departamentos, "idDepto", "Nombre", solicitudes.idDepartamento_Origen);
            ViewBag.idDepartamento_Destino = new SelectList(db.Cat_Departamentos, "idDepto", "Nombre", solicitudes.idDepartamento_Destino);
            ViewBag.idEstado = new SelectList(db.Cat_Estado_Solicitud, "idEstado", "Nombre", solicitudes.idEstado);
            ViewBag.idPeriodo = new SelectList(db.Cat_Periodo_Modificaciones, "idPeriodo", "idPeriodo", solicitudes.idPeriodo);
            ViewBag.idTipoSolicitud = new SelectList(db.Cat_Solicitudes, "idTipoSolicitud", "Nombre", solicitudes.idTipoSolicitud);
            ViewBag.idSolicitante = new SelectList(db.Empleados, "idEmpleado", "Nombre", solicitudes.idSolicitante);
            return View(solicitudes);
        }

        // GET: Solicitudes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitudes solicitudes = db.Solicitudes.Find(id);
            if (solicitudes == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDepartamento_Origen = new SelectList(db.Cat_Departamentos, "idDepto", "Nombre", solicitudes.idDepartamento_Origen);
            ViewBag.idDepartamento_Destino = new SelectList(db.Cat_Departamentos, "idDepto", "Nombre", solicitudes.idDepartamento_Destino);
            ViewBag.idEstado = new SelectList(db.Cat_Estado_Solicitud, "idEstado", "Nombre", solicitudes.idEstado);
            ViewBag.idPeriodo = new SelectList(db.Cat_Periodo_Modificaciones, "idPeriodo", "idPeriodo", solicitudes.idPeriodo);
            ViewBag.idTipoSolicitud = new SelectList(db.Cat_Solicitudes, "idTipoSolicitud", "Nombre", solicitudes.idTipoSolicitud);
            ViewBag.idSolicitante = new SelectList(db.Empleados, "idEmpleado", "Nombre", solicitudes.idSolicitante);
            return View(solicitudes);
        }

        // POST: Solicitudes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSolicitud,idTipoSolicitud,idSolicitante,idPeriodo,idDepartamento_Origen,CodPartida_Origen,idDepartamento_Destino,CodPartida_Destino,Monto_Solicitado,Fecha_Solicitud,Fecha_Respuesta,idEstado")] Solicitudes solicitudes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitudes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDepartamento_Origen = new SelectList(db.Cat_Departamentos, "idDepto", "Nombre", solicitudes.idDepartamento_Origen);
            ViewBag.idDepartamento_Destino = new SelectList(db.Cat_Departamentos, "idDepto", "Nombre", solicitudes.idDepartamento_Destino);
            ViewBag.idEstado = new SelectList(db.Cat_Estado_Solicitud, "idEstado", "Nombre", solicitudes.idEstado);
            ViewBag.idPeriodo = new SelectList(db.Cat_Periodo_Modificaciones, "idPeriodo", "idPeriodo", solicitudes.idPeriodo);
            ViewBag.idTipoSolicitud = new SelectList(db.Cat_Solicitudes, "idTipoSolicitud", "Nombre", solicitudes.idTipoSolicitud);
            ViewBag.idSolicitante = new SelectList(db.Empleados, "idEmpleado", "Nombre", solicitudes.idSolicitante);
            return View(solicitudes);
        }

        // GET: Solicitudes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitudes solicitudes = db.Solicitudes.Find(id);
            if (solicitudes == null)
            {
                return HttpNotFound();
            }
            return View(solicitudes);
        }

        // POST: Solicitudes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Solicitudes solicitudes = db.Solicitudes.Find(id);
            db.Solicitudes.Remove(solicitudes);
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

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AprobarSolicitud()
        {
            Solicitudes solicitudes = new Solicitudes();


            try
            {
                // Your connection string
                string connectionString = "Data Source = tiusr11pl.cuc-carrera-ti.ac.cr\\MSSQLSERVER2019; Initial Catalog = tiusr11pl_MODIFICACION_PRESUPUESTOS; User ID = Modificacion_Ajustes_P; Password=Modificacion123!!!; Encrypt=False";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Call the stored procedure
                    using (SqlCommand cmd = new SqlCommand("dbo.Aprobar_Solicitud", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idSolicitud", solicitudes.idSolicitud);
                        cmd.Parameters.AddWithValue("@idResponsable", solicitudes.idSolicitante);

                        // Execute the stored procedure
                        cmd.ExecuteNonQuery();
                    }
                }

                // Solicitud aprobada successfully, return a success response or redirect to appropriate view
                return new HttpStatusCodeResult(HttpStatusCode.OK);

            }
            catch (SqlException ex)
            {
                // Handle the SQL exception, return an error response or redirect to appropriate error view
                return RedirectToAction("Error", "YourController", new { message = ex.Message });
            }
        }

        // Other methods in your controller here...
    }

}

