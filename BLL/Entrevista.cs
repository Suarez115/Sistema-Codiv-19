using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Entrevista
    {
        public string login { get; set; }
        public string nombreCompleto { get; set; }
        public int cedula { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public int rubroPresentacion { get; set; }
        public int rubroHabilidadesBlandas { get; set; }
        public int rubroHabilidadesComportamiento { get; set; }
        public int rubroHabilidadesSituacionales { get; set; }
        public int rubroHabilidadesDuras { get; set; }
        public int calificacionFinal { get; set; }
    }
}
