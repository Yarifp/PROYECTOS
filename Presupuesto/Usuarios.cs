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
    
    public partial class Usuarios
    {
        public int idUsuario { get; set; }
        public string Usuario { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Correo_electronico { get; set; }
        public string Contrasena { get; set; }
        public int idDepto { get; set; }
        public int idRol { get; set; }
        public int idEmpleado { get; set; }
        public int idEstado { get; set; }
    
        public virtual Cat_Departamentos Cat_Departamentos { get; set; }
        public virtual Cat_Estado_Usuario Cat_Estado_Usuario { get; set; }
        public virtual Cat_Roles Cat_Roles { get; set; }
        public virtual Empleados Empleados { get; set; }
    }
}
