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
    internal class AlbumADO
    {
        private string Conexion = ConfigurationManager.ConnectionStrings["SQLConection"].ConnectionString;
        internal Album BuscarAlbum(string Value)
        {
            Album alb = new Album();
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                string sentencia = "exec Compurent_User_Historys 1,'" + Value + "',''";
                SqlCommand cmd = new SqlCommand(sentencia, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                
                while (rdr.Read())
                {
                    alb.id = rdr[0] == DBNull.Value ? 0 : rdr.GetInt32(0);
                    alb.Name = rdr[1] == DBNull.Value ? "" : rdr.GetString(1).Trim();
                }
                con.Close();
                return alb;
            }
        }

        internal List<Album> ListarAlbum() 
        { 
            List<Album> alb = new List<Album>();
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                string sentencia = "exec Compurent_User_Historys 2,'',''";
                SqlCommand cmd = new SqlCommand(sentencia, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Album al = new Album();
                    al.id = rdr[0] == DBNull.Value ? 0 : rdr.GetInt32(0);
                    al.Name = rdr[1] == DBNull.Value ? "" : rdr.GetString(1).Trim();
                    alb.Add(al);
                }
                con.Close();
                return alb;

            }
        }
        internal void CrearAlbum(string NombAlb)
        {
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                string sentencia = "exec Compurent_User_Historys 3,'"+NombAlb+"',''";
                SqlCommand cmd = new SqlCommand(sentencia, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        internal void EditarAlbum(Album NombAlb)
        {
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                string sentencia = "exec Compurent_User_Historys 4,'" + NombAlb.Name + "','"+NombAlb.id+"'";
                SqlCommand cmd = new SqlCommand(sentencia, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        internal Album BuscarAlbumById(int id)
        {
            Album alb = new Album();
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                string sentencia = "exec Compurent_User_Historys 5,'','"+id+"'";
                SqlCommand cmd = new SqlCommand(sentencia, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    alb.id = rdr[0] == DBNull.Value ? 0 : rdr.GetInt32(0);
                    alb.Name = rdr[1] == DBNull.Value ? "" : rdr.GetString(1).Trim();
                }
                con.Close();
                return alb;
            }
        }
        internal string EliminarAlbum(int id)
        {
            try
            {
                string respuesta = null;
                using (SqlConnection con = new SqlConnection(Conexion))
                {

                    string sentencia = "exec Compurent_User_Historys 6,'','" + id + "'";
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
            catch (Exception )
            {
                throw;
            }
        }
    }
}
