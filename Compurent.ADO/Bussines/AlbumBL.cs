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
        internal List<Album> ListarAlbum()
        {
            return new AlbumADO().ListarAlbum();
        }

        internal void CrearAlbum(string NombAlb)
        {
            new AlbumADO().CrearAlbum(NombAlb);
        }
        internal void EditarAlbum(Album NombAlb)
        {
            new AlbumADO().EditarAlbum(NombAlb);
        }

        internal Album BuscarAlbumById(int id)
        {
            return new AlbumADO().BuscarAlbumById(id);
        }
        internal string EliminarAlbum(int id)
        {
            return new AlbumADO().EliminarAlbum(id);
        }
    }
}
