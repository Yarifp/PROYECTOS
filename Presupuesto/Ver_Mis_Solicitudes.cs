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
    
    public partial class Ver_Mis_Solicitudes
    {
        public int ID { get; set; }
        public string Tipo { get; set; }
        public string Solicitante { get; set; }
        public int Periodo { get; set; }
        public Nullable<int> Depto { get; set; }
        public string Depto_Origen { get; set; }
        public string Codigo_PartidaOrigen { get; set; }
        public string Partida_Origen { get; set; }
        public string Depto_Destino { get; set; }
        public string Codigo_PartidaDestino { get; set; }
        public string Partida_Destino { get; set; }
        public decimal Monto { get; set; }
        public System.DateTime Fecha_Solicitud { get; set; }
        public System.DateTime Fecha_Respuesta { get; set; }
        public string Estado_Solicitud { get; set; }
    }
}
