using Compurent.ADO.Bussines;
using Compurent.ADO.Masters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compurent.ADO.ToFront
{
    public  class Front
    {
        public Album BuscarAlbum(string Value)
        {
            return new AlbumBL().BuscarAlbum(Value);
        }
    }
}
