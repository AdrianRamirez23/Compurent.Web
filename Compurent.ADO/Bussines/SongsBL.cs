using Compurent.ADO.Masters.ADO;
using Compurent.ADO.Masters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compurent.ADO.Bussines
{
    internal class SongsBL
    {
        internal List<Songs> ListarCanciones()
        {
            return new SongsADO().ListarCanciones();
        }
        internal void CrearCanciones(Songs song)
        {
            new SongsADO().CrearCancion(song);
        }
        internal Songs BuscarCancion(int id)
        {
            return new SongsADO().BuscarCancion(id);
        }
        internal void EditarCancion(Songs song)
        {
            new SongsADO().EditarCancion(song);
        }
        internal string EliminarCancion(int id)
        {
            return new SongsADO().EliminarCancion(id);
        }
    }
}
