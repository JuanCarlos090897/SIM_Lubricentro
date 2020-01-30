using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIM_Lubricentro.Models
{
    public class Personal
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Telofono { get; set; }
        public string Correo { get; set; }
        public string Cedula { get; set; }
        public string Celular { get; set; }
        public string PuestoDeTrabajo { get; set; }

        public virtual IEnumerable<Historial> Historiales { get; set; }
        public virtual IEnumerable<RealizarReparacion> RealizarReparaciones { get; set; }
    }
}
