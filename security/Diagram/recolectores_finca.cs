//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Diagram
{
    using System;
    using System.Collections.Generic;
    
    public partial class recolectores_finca
    {
        public int id { get; set; }
        public Nullable<int> recolector_id { get; set; }
        public Nullable<int> finca_id { get; set; }
    
        public virtual finca finca { get; set; }
        public virtual recolector recolector { get; set; }
    }
}
