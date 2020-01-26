using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SIM_Lubricentro.Models
{
    public class Carro
    {
        public int ID { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }

        public int Cliente_ID { get; set; }
        [ForeignKey("Cliente_ID")]
        public virtual Cliente Cliente { get; set; }

        public virtual IEnumerable<Reparacion> Reparaciones { get; set; }
    }
}
