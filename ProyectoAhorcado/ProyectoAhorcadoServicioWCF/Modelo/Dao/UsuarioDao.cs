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
        private const string OBTENER_INFORMACION_USUARIO = "SELECT * FROM usuario WHERE idusuario = @idusuario";
        private const string MODIFICAR_INFORMACION_USUARIO = "UPDATE usuario SET nombreCompleto = @nombreCompleto, password = @password, telefono = @telefono, " +
            "fechaNacimiento = @fechaNacimiento WHERE idusuario = @idusuario";
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


        public static Usuario obtenerInfoUsuario(int idUsuario)
        {
            Usuario infoUsuario = null;
            MySqlConnection conexionBD = ConnectionUtil.obtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    MySqlCommand mySqlCommand = new MySqlCommand(OBTENER_INFORMACION_USUARIO, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idusuario", idUsuario);
                    MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                    if (mySqlDataReader.Read())
                    {
                        infoUsuario = new Usuario();
                        infoUsuario.idUsuario = ((mySqlDataReader.IsDBNull(0)) ? 0 : mySqlDataReader.GetInt32(0));
                        infoUsuario.nombreCompleto = ((mySqlDataReader.IsDBNull(1)) ? "" : mySqlDataReader.GetString(1));
                        infoUsuario.password = ((mySqlDataReader.IsDBNull(2)) ? "" : mySqlDataReader.GetString(2));
                        infoUsuario.telefono = ((mySqlDataReader.IsDBNull(3)) ? "" : mySqlDataReader.GetString(3));
                        infoUsuario.correoElectronico = ((mySqlDataReader.IsDBNull(4)) ? "" : mySqlDataReader.GetString(4));
                        infoUsuario.fechaNacimiento = mySqlDataReader.GetDateTime(5);
                        return infoUsuario;
                    }
                }
                catch (MySqlException ex)
                {
                    MySqlException exSQL = (MySqlException)Activator.CreateInstance(ex.GetType(), "Error de sql", ex);
                    throw exSQL;
                }
            }
            return infoUsuario;
        }

        public static Boolean modificarInformacionUsuario(string nombreCompleto, string password, string telefono, DateTime fechaNacimiento, int idUsuario)
        {
            MySqlConnection conexionBD = ConnectionUtil.obtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    MySqlCommand mySqlCommand = new MySqlCommand(MODIFICAR_INFORMACION_USUARIO, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@nombreCompleto", nombreCompleto);
                    mySqlCommand.Parameters.AddWithValue("@password", password);
                    mySqlCommand.Parameters.AddWithValue("@telefono", telefono);
                    mySqlCommand.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
                    mySqlCommand.Parameters.AddWithValue("@idusuario", idUsuario);
                    mySqlCommand.Prepare();
                    int filasAfectadas = mySqlCommand.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (MySqlException ex)
                {
                    MySqlException exSQL = (MySqlException)Activator.CreateInstance(ex.GetType(), "Error de sql", ex);
                    throw exSQL;
                }
            }
            return false;
        }
    }
}