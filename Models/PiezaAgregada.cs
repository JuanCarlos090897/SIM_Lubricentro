using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SIM_Lubricentro.Models
{
    public class PiezaAgregada
    {
        public int ID { get; set; }
        public string CodigoProducto { get; set; }
        public string Descripcion { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaPiezaAgregada { get; set; } // aqui voy a poner la fecha en que se agrega al sistema el producto agregado al carro

        public int Carro_ID { get; set; } // esta la llave foranea con el id del carro al cual se le agrego 
        [ForeignKey("Carro_ID")]
        public virtual Carro Carro { get; set; }
    }
}
