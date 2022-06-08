using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAhorcadoServicioWCF.Modelo.Poco
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string nombreCompleto { get; set; }
        public string password { get; set; }
        public string telefono { get; set; }
        public string correoElectronico { get; set; }
        public DateTime fechaNacimiento { get; set; }

    }
}