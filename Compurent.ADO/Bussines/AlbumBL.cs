using Compurent.ADO.Masters.ADO;
using Compurent.ADO.Masters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compurent.ADO.Bussines
{
    internal class AlbumBL
    {
        internal Album BuscarAlbum(string Value)
        {
            return new AlbumADO().BuscarAlbum(Value);
        }
    }
}
