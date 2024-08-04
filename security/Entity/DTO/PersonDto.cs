using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Primer_nombre { get; set; }
        public string Segundo_nombre { get; set; }
        public string Primer_aPellido { get; set; }
        public string Segundo_apellido { get; set; }
    }
}
