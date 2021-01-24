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
    internal class UserAdminADO
    {
        private string Conexion = ConfigurationManager.ConnectionStrings["SQLConection"].ConnectionString;

        internal UserAdmin ValidarSesion(string User, string Password)
        {
            UserAdmin uss = new UserAdmin();
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                string sentencia = "exec Compurent_UserAdmin_History 1,'','"+Password+"','','"+User+"','',''";
                SqlCommand cmd = new SqlCommand(sentencia, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    uss.id = rdr[0] == DBNull.Value ? "" : rdr.GetString(0).Trim();
                    uss.Password = rdr[1] == DBNull.Value ? "" : rdr.GetString(1).Trim();
                    uss.NameUser = rdr[2] == DBNull.Value ? "" : rdr.GetString(2).Trim();
                    uss.EmailUser = rdr[3] == DBNull.Value ? "" : rdr.GetString(3).Trim();
                    uss.Adress = rdr[4] == DBNull.Value ? "" : rdr.GetString(4).Trim();
                    uss.PhoneUser = rdr[5] == DBNull.Value ? "" : rdr.GetString(5).Trim();
                }
                con.Close();
                return uss;
            }
        }
        internal string RegistrarUsuario(UserAdmin ussr)
        {
            try
            {
                string respuesta = null;
                using (SqlConnection con = new SqlConnection(Conexion))
                {

                    string sentencia = "exec Compurent_UserAdmin_History 2,'"+ussr.id+"','" + ussr.Password + "','"+ussr.NameUser+"','" + ussr.EmailUser + "','"+ussr.Adress+"','"+ussr.PhoneUser+"'";
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
