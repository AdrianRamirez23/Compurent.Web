using Compurent.ADO.Masters.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compurent.ADO.Masters.ADO
{
    internal class SongsADO
    {
        private string Conexion = ConfigurationManager.ConnectionStrings["SQLConection"].ConnectionString;
        internal List<Songs> ListarCanciones()
        {
            List<Songs> songs = new List<Songs>();
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                string sentencia = "exec Compurent_User_History_Songs 1,'','',''";
                SqlCommand cmd = new SqlCommand(sentencia, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Songs song = new Songs();
                    song.id = rdr[0] == DBNull.Value ? 0 : rdr.GetInt32(0);
                    song.Name = rdr[1] == DBNull.Value ? "" : rdr.GetString(1).Trim();
                    song.Album_id = rdr[2] == DBNull.Value ? 0 : rdr.GetInt32(2);
                    songs.Add(song);
                }
                con.Close();
                return songs;

            }
        }
        internal void CrearCancion(Songs song)
        {
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                string sentencia = "exec Compurent_User_History_Songs 2,'" + song.Name + "','"+song.Album_id+"',''";
                SqlCommand cmd = new SqlCommand(sentencia, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        internal Songs BuscarCancion(int id)
        {
            Songs song = new Songs();
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                string sentencia = "exec Compurent_User_History_Songs 3,'','','"+id+"'";
                SqlCommand cmd = new SqlCommand(sentencia, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    song.id = rdr[0] == DBNull.Value ? 0 : rdr.GetInt32(0);
                    song.Name = rdr[1] == DBNull.Value ? "" : rdr.GetString(1).Trim();
                    song.Album_id = rdr[2] == DBNull.Value ? 0 : rdr.GetInt32(2);
                }
                con.Close();
                return song;
            }
        }
        internal void EditarCancion(Songs song)
        {
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                string sentencia = "exec Compurent_User_History_Songs 4,'" + song.Name + "','" + song.Album_id + "','"+song.id+"'";
                SqlCommand cmd = new SqlCommand(sentencia, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        internal string EliminarCancion(int id)
        {
            try
            {
                string respuesta = null;
                using (SqlConnection con = new SqlConnection(Conexion))
                {
                    string sentencia = "exec Compurent_User_History_Songs 5,'','','" + id + "'";
                    SqlCommand cmd = new SqlCommand(sentencia, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        respuesta = rdr[0] == DBNull.Value ? "" : rdr.GetString(0);
                    }
                    con.Close();
                    return respuesta;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
