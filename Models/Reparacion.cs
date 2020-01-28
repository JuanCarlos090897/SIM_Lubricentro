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
        public string Reparaciones { get; set; }// aqui se le da la descripcion de la Reparacion ej: Cmabio dce llantas

        
    }
}
