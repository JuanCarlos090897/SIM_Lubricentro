using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SIM_Lubricentro.Models
{
    public class Reparacion
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public bool Realizado { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        public int Carro_ID { get; set; }
        [ForeignKey("Carro_ID")]
        public virtual Carro Carro { get; set; }

        public int Personal_ID { get; set; }
        [ForeignKey("Personal_ID")]
        public virtual Personal Personal { get; set; }
    }
}
