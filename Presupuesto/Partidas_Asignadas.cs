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
    
    public partial class Partidas_Asignadas
    {
        public int idAsig { get; set; }
        public string CodigoPartida { get; set; }
        public int idDepartamento { get; set; }
        public Nullable<decimal> Monto_asignado { get; set; }
    
        public virtual Cat_Departamentos Cat_Departamentos { get; set; }
    }
}
