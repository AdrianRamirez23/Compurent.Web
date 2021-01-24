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
        public List<Album> ListarAlbum()
        {
            return new AlbumBL().ListarAlbum();
        }
        public void CrearAlbum(string NombAlb)
        {
            new AlbumBL().CrearAlbum(NombAlb);
        }
        public void EditarAlbum(Album NombAlb)
        {
            new AlbumBL().EditarAlbum(NombAlb);
        }

        public Album BuscarAlbumById(int id)
        {
            return new AlbumBL().BuscarAlbumById(id);
        }
        public string EliminarAlbum(int id)
        {
           return  new AlbumBL().EliminarAlbum(id);
        }
    }
}
