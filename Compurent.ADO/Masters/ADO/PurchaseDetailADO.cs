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
    internal class PurchaseDetailADO
    {
        private string Conexion = ConfigurationManager.ConnectionStrings["SQLConection"].ConnectionString;

        internal List<PurchaseDetail> ListarPedidos(string id)
        {
            List<PurchaseDetail> dets = new List<PurchaseDetail>();
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                string sentencia = "exec Compurent_PurchaseDetails_History 1,'"+id+"','',''";
                SqlCommand cmd = new SqlCommand(sentencia, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    PurchaseDetail det = new PurchaseDetail();
                    det.Client_id = rdr[0] == DBNull.Value ? "" : rdr.GetString(0);
                    det.Album_id = rdr[1] == DBNull.Value ? 0: rdr.GetInt32(1);
                    det.Total = rdr[1] == DBNull.Value ? 0 : Convert.ToDouble(rdr.GetValue(2));
                    det.id = rdr[3] == DBNull.Value ? 0 : rdr.GetInt32(3);
                    dets.Add(det);
                }
                con.Close();
                return dets;
            }
        }
        internal void CrearPedido(PurchaseDetail detail)
        {
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                string sentencia = "exec Compurent_PurchaseDetails_History 2,'" + detail.Client_id + "','" + detail.Album_id + "','"+detail.Total+"'";
                SqlCommand cmd = new SqlCommand(sentencia, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
