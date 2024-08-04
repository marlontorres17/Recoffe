using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class View
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Ruta { get; set; }

        public int ModuleId { get; set; }
        public Module module { get; set; }
    }
}
