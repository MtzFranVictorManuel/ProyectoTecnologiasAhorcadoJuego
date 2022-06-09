using ProyectoAhorcadoServicioWCF.Modelo.Dao;
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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IAhorcadoServicio
    {
        public Boolean registrarUsuario(string nombre, string apellidos, string password, string telefono, string correoElectronico, DateTime fechaNacimiento)
        {
            Usuario nuevoUsuario = new Usuario();
            nuevoUsuario.nombreCompleto = nombre + " " + apellidos;
            nuevoUsuario.password = password;
            nuevoUsuario.telefono = telefono;
            nuevoUsuario.correoElectronico = correoElectronico;
            nuevoUsuario.fechaNacimiento = fechaNacimiento;
            Boolean registrarNuevoUsuario = UsuarioDao.insertarUsuario(nuevoUsuario);
            return registrarNuevoUsuario;
        }
    }
}
