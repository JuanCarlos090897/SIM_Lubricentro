using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SIM_Lubricentro.Models;

namespace SIM_Lubricentro.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SIM_Lubricentro.Models.Cliente> Cliente { get; set; }
        public DbSet<SIM_Lubricentro.Models.Carro> Carro { get; set; }
        public DbSet<SIM_Lubricentro.Models.Personal> Personal { get; set; }
        public DbSet<SIM_Lubricentro.Models.Reparacion> Reparacion { get; set; }
        public DbSet<SIM_Lubricentro.Models.RealizarReparacion> RealizarReparacion { get; set; }
    }
}
