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
        public string TipoPersonal { get; set; }

        public virtual IEnumerable<Reparacion> Reparaciones { get; set; }
    }
}
