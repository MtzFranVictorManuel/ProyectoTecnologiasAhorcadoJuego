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

        // TODO: agregue aquí sus operaciones de servicio
    }

}
