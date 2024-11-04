using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Evaluacion
    {
        public string login { get; set; }
        public string nombreEmpleado { get; set; }
        public int cedula { get; set; }
        public int puntualidad { get; set; }
        public int logros { get; set; }
        public int trabajoEnEquipo { get; set; }
        public int desempenoIndividual { get; set; }
        public int habilidadesTecnicas { get; set; }
        public int calificacionFinal { get; set; }
    }
}
