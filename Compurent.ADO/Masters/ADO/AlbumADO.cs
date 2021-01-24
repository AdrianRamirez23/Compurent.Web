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
                string sentencia = "exec Compurent_User_Historys 1,'" + Value + "'";
                SqlCommand cmd = new SqlCommand(sentencia, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                con.Close();
                while (rdr.Read())
                {
                    alb.id = rdr[0] == DBNull.Value ? 0 : rdr.GetInt32(0);
                    alb.Name = rdr[1] == DBNull.Value ? "" : rdr.GetString(1).Trim();
                }
                return alb;
            }
        }
    }
}
