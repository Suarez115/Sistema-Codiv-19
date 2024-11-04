using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Empleados
    {
        public int cedula { get; set; }
        public string nombreCompleto { get; set; }
        public DateTime fechaNaciemiento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string cargo { get; set; }
        public byte[] foto { get; set; }
    }
}
