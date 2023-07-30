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

        //Aprobar Solicitudes
        public async Task<ActionResult> AprobarSolicitud(int id, int idResponsable)
        {
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
                        cmd.Parameters.AddWithValue("@idSolicitud", id);
                        // Assuming that you have a variable to store the id of the responsible person (idResponsable)
                        cmd.Parameters.AddWithValue("@idResponsable", idResponsable);

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AprobSoli(int id)
        {


            try
            {
                ActionResult result = await AprobarSolicitud(id, 1);

                await Task.Delay(1000); // Simulando una tarea asincrónica.

                var successMessage = "Solicitud aprobada exitosamente.";
                TempData["SuccessMessage"] = successMessage;

                // Redirigir de vuelta a la vista Edit con un mensaje de éxito
                // return Json(new { Success = true, Message = successMessage });
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que ocurra durante la aprobación.
                // Aquí puedes realizar un seguimiento de los errores o registrarlos para su posterior revisión.

                // En caso de error, podemos devolver un código de estado HTTP 500 (Error interno del servidor).
                var errorMessage = "Hubo un error al aprobar la solicitud.";
                TempData["ErrorMessage"] = errorMessage;

                // Redirigir de vuelta a la vista Edit con un mensaje de error
                return RedirectToAction("Index");
            }
        }

        //Rechazar Solicitudes
        public async Task<ActionResult> RechazarSolicitud(int id, int idResponsable)
        {
            try
            {
                // Your connection string
                string connectionString = "Data Source = tiusr11pl.cuc-carrera-ti.ac.cr\\MSSQLSERVER2019; Initial Catalog = tiusr11pl_MODIFICACION_PRESUPUESTOS; User ID = Modificacion_Ajustes_P; Password=Modificacion123!!!; Encrypt=False";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Call the stored procedure
                    using (SqlCommand cmd = new SqlCommand("dbo.Rechazar_Solicitud", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idSolicitud", id);
                        // Assuming that you have a variable to store the id of the responsible person (idResponsable)
                        cmd.Parameters.AddWithValue("@idResponsable", idResponsable);

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RechaSoli(int id)
        {


            try
            {
                ActionResult result = await RechazarSolicitud(id, 1);

                await Task.Delay(1000); // Simulando una tarea asincrónica.

                var successMessage = "Solicitud rechazada exitosamente.";
                TempData["SuccessMessage"] = successMessage;

                // Redirigir de vuelta a la vista Edit con un mensaje de éxito
                // return Json(new { Success = true, Message = successMessage });
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que ocurra durante la aprobación.
                // Aquí puedes realizar un seguimiento de los errores o registrarlos para su posterior revisión.

                // En caso de error, podemos devolver un código de estado HTTP 500 (Error interno del servidor).
                var errorMessage = "Hubo un error al rechazar la solicitud.";
                TempData["ErrorMessage"] = errorMessage;

                // Redirigir de vuelta a la vista Edit con un mensaje de error
                return RedirectToAction("Index");
            }
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
