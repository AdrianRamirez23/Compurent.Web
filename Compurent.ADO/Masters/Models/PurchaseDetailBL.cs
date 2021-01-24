using Compurent.ADO.Masters.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compurent.ADO.Masters.Models
{
    internal class PurchaseDetailBL
    {
        internal List<PurchaseDetail> ListaPedidos(string id)
        {
            return new PurchaseDetailADO().ListarPedidos(id);
        }
        internal void CrearPedido(PurchaseDetail detail)
        {
            new PurchaseDetailADO().CrearPedido(detail);
        }
    }
}
