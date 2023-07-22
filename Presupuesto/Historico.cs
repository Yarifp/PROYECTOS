//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Presupuesto
{
    using System;
    using System.Collections.Generic;
    
    public partial class Historico
    {
        public int ID { get; set; }
        public int idPeriodo { get; set; }
        public int idSolicitud { get; set; }
        public int idTipoSolicitud { get; set; }
        public System.DateTime Fecha_Solicitud { get; set; }
        public System.DateTime Fecha_Respuesta { get; set; }
        public int idDepto_Origen { get; set; }
        public string CodPartida_Origen { get; set; }
        public decimal Saldo_Origen_Inicial { get; set; }
        public decimal Monto_Solicitud { get; set; }
        public Nullable<decimal> Nuevo_Saldo_Origen { get; set; }
        public int idDepartamento_Destino { get; set; }
        public string CodPartida_Destino { get; set; }
        public Nullable<decimal> Saldo_Destino_Inicial { get; set; }
        public decimal Monto_Solicitud2 { get; set; }
        public Nullable<decimal> Nuevo_Saldo_Destino { get; set; }
        public int idSolicitante { get; set; }
        public int idResponsable { get; set; }
        public int idEstado { get; set; }
    
        public virtual Cat_Departamentos Cat_Departamentos { get; set; }
        public virtual Cat_Departamentos Cat_Departamentos1 { get; set; }
        public virtual Cat_Estado_Solicitud Cat_Estado_Solicitud { get; set; }
        public virtual Cat_Periodo_Modificaciones Cat_Periodo_Modificaciones { get; set; }
        public virtual Cat_Solicitudes Cat_Solicitudes { get; set; }
        public virtual Empleados Empleados { get; set; }
        public virtual Empleados Empleados1 { get; set; }
        public virtual Solicitudes Solicitudes { get; set; }
    }
}
