using Compurent.ADO.Masters.Models;
using Compurent.ADO.ToFront;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Compurent.Web.Controllers
{
    public class AlbumController : Controller
    {
        // GET: Album
        public ActionResult Index(string value)
        {
            try
            {
                Album alb = new Album();
                alb = new Front().BuscarAlbum(value);

                Compurent.Web.Models.Album albu = new Compurent.Web.Models.Album();
                albu.id = alb.id;
                albu.Name = alb.Name;

                return View(albu);
            }
            catch (Exception e )
            {

                throw;
            }
        }
    }
}