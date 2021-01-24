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
        public List<Songs> ListarCanciones()
        {
            return new SongsBL().ListarCanciones();
        }
        public void CrearCancion(Songs song) 
        {
            new SongsBL().CrearCanciones(song);
        }
        public Songs BuscarCancion(int id)
        {
            return new SongsBL().BuscarCancion(id);
        }
        public void EditarCancion(Songs song)
        {
            new SongsBL().EditarCancion(song);
        }
        public string EliminarCancion(int id)
        {
            return new SongsBL().EliminarCancion(id);
        }
        public UserAdmin ValidarSesion(string User, string Password)
        {
            return new UserAdminBL().ValidarSesion(User, Password);
        }
        public string RegistrarUsuario(UserAdmin ussr)
        {
            return new UserAdminBL().RegistrarUsuario(ussr);
        }
        public List<PurchaseDetail> ListaPedidos(string id)
        {
            return new PurchaseDetailBL().ListaPedidos(id);
        }
        public void CrearPedido(PurchaseDetail detail)
        {
            new PurchaseDetailBL().CrearPedido(detail);
        }
    }
}
