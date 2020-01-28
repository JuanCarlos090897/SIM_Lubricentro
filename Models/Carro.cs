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
        public string Vehiculo { get; set; }
        public string Estilo { get; set; }
        public string Año { get; set; }
        public string Kms { get; set; }

        public int Cliente_ID { get; set; }
        [ForeignKey("Cliente_ID")]
        public virtual Cliente Cliente { get; set; }

        public virtual IEnumerable<PiezaAgregada> PiezasAgregadas { get; set; }
        public virtual IEnumerable<Historial> Historiales { get; set; }
        public virtual IEnumerable<RealizarReparacion> RealizarReparaciones { get; set; }
    }
}
