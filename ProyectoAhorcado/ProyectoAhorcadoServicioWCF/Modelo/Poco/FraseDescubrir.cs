using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAhorcadoServicioWCF.Modelo.Poco
{
    public class FraseDescubrir
    {
        public int idFraseDescubrir { get; set; }
        public string descripcion { get; set; }
        public int longitudFrase { get; set; }
        public int palabra { get; set; }
        public int idCategoria { get; set; }

    }
}