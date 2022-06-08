using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAhorcadoServicioWCF.Modelo.Poco
{
    public class Partida
    {
        public int idPartida { get; set; }
        public DateTime fechaPartida { get; set; }
        public int puntaje { get; set; }
        public string ganador { get; set; }
        public int estadoPartida { get; set; }
        public int idUsuarioRetador { get; set; }
        public int idUsuarioCreador { get; set; }
        public int idFraseDescubrir { get; set; }

    }
}