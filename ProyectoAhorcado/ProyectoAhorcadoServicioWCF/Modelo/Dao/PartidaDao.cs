using MySql.Data.MySqlClient;
using ProyectoAhorcadoServicioWCF.Modelo.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAhorcadoServicioWCF.Modelo.Dao
{
    public class PartidaDao
    {
        public static List<Partida> obtenerPartidas(int idUsuario)
        {
            List<Partida> partidaList = null;
            Partida partida = null;
            MySqlConnection conexionBD = ConnectionUtil.obtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    string OBTENER_LISTA_PARTIDA = String.Format("select p.fechaPartida, p.puntaje, u.nombreCompleto from partida p inner join usuario u on p.idusuarioRetador = u.idUsuario where p.idusuarioCreador = {0}", idUsuario);
                    MySqlCommand mySqlCommand = new MySqlCommand(OBTENER_LISTA_PARTIDA, conexionBD);
                    MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                    partidaList = new List<Partida>();
                    while (mySqlDataReader.Read())
                    {
                        partida = new Partida();
                        partida.fechaPartida = mySqlDataReader.GetDateTime(0);
                        partida.puntaje = ((mySqlDataReader.IsDBNull(1)) ? 0 : mySqlDataReader.GetInt32(1));
                        partida.ganador = ((mySqlDataReader.IsDBNull(2)) ? "" : mySqlDataReader.GetString(2));
                        partidaList.Add(partida);
                    }
                    if (partidaList.LongCount() != 0)
                    {
                        return partidaList;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (MySqlException ex)
                {
                    MySqlException exSQL = (MySqlException)Activator.CreateInstance(ex.GetType(), "Error de sql", ex);
                    throw exSQL;
                }
            }
            return partidaList;
        }
    }
}