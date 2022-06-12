using ProyectoAhorcadoServicioWCF.Modelo.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ProyectoAhorcadoServicioWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAhorcadoServicio
    {

        [OperationContract]
        Boolean registrarUsuario(string nombre, string apellidos, string password, string telefono, string correoElectronico, DateTime fechaNacimiento);
        [OperationContract]
        Usuario obtenerUsuarioJugador(int idUsuario);
        [OperationContract]
        Boolean modificarUsuario(string nombreCompleto, string password, string telefono, DateTime fechaNacimiento, int idUsuario);
        [OperationContract]
        List<Partida> obtenerPartidasJugadas(int idUsuario);
        // TODO: agregue aquí sus operaciones de servicio
    }

}
