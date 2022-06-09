using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using ProyectoAhorcadoServicioWCF.Modelo.Poco;

namespace ProyectoAhorcadoServicioWCF.Modelo.Dao
{
    public class UsuarioDao
    {
        private const string REGISTRAR_USUARIO = "INSERT INTO usuario (nombreCompleto, password, telefono, correoElectronico, fechaNacimiento) VALUES " +
            "(@nombreCompleto, @password, @telefono, @correoElectronico, @fechaNacimiento)";
        public static Boolean insertarUsuario(Usuario usuario)
        {
            Boolean resultado = false;
            MySqlConnection conexionBD = ConnectionUtil.obtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    MySqlCommand mySqlCommand = new MySqlCommand(REGISTRAR_USUARIO, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@nombreCompleto", usuario.nombreCompleto);
                    mySqlCommand.Parameters.AddWithValue("@password", usuario.password);
                    mySqlCommand.Parameters.AddWithValue("@telefono", usuario.telefono);
                    mySqlCommand.Parameters.AddWithValue("@correoElectronico", usuario.correoElectronico);
                    mySqlCommand.Parameters.AddWithValue("@fechaNacimiento", usuario.fechaNacimiento);
                    mySqlCommand.Prepare();
                    int filasAfectadas = mySqlCommand.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        return resultado = true;
                    }
                    else
                    {
                        return resultado;
                    }
                }
                catch (MySqlException ex)
                {
                    MySqlException exSQL = (MySqlException) Activator.CreateInstance(ex.GetType(), "Error de sql", ex);
                    throw exSQL;
                }
            }
            return resultado;
        }
    }
}