using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIM_Lubricentro.Models
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Telofono { get; set; }
        public string Correo { get; set; }
        public string Cedula { get; set; }

        public virtual IEnumerable<Carro> Carros { get; set; } // esto es para mandar la llave foranea a Carro
    }
}
