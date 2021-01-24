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
        // GET: Album by Song's Nae or Album's Name
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
                Request.Flash("danger", e.Message);
                return View();
            }
        }
        // GET: Albumn's List
        public ActionResult ListarAlbum()
        {
            try
            {
                List<Album>alb = new List<Album>();
                alb = new Front().ListarAlbum();

                List<Compurent.Web.Models.Album> albu = new List<Compurent.Web.Models.Album>();

                foreach(Album al in alb)
                {
                    Compurent.Web.Models.Album albus = new Compurent.Web.Models.Album();
                    albus.id = al.id;
                    albus.Name = al.Name;
                    albu.Add(albus);
                }

                return View(albu);
            }
            catch (Exception e)
            {
                Request.Flash("danger", e.Message);
                throw;
            }
        }

        public ActionResult AgregarAlbum()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarAlbum(Compurent.Web.Models.Album  NombAlb)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                 new Front().CrearAlbum(NombAlb.Name);
                 return RedirectToAction("ListarAlbum");

            }
            catch (Exception ex)
            {
                Request.Flash("danger", ex.Message);
                return View();
            }
        }
        public ActionResult EditarAlbum(int Id)
        {
            try
            {
                Album alb = new Album();
                alb = new Front().BuscarAlbumById(Id);
                Compurent.Web.Models.Album albu = new Compurent.Web.Models.Album();
                albu.id = alb.id;
                albu.Name = alb.Name;
                return View(albu); 
            }
            catch (Exception e)
            {
                Request.Flash("danger", e.Message);
                throw;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarAlbum(Compurent.Web.Models.Album alb)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                Album albu = new Album();
                albu.id = alb.id;
                albu.Name = alb.Name;
                new Front().EditarAlbum(albu);
                return RedirectToAction("ListarAlbum");
            }
            catch (Exception e)
            {
                Request.Flash("danger", e.Message);
                throw;
            }
        }
        public ActionResult EliminarAlbum(int id)
        {
            try
            {
               string respuesta=  new Front().EliminarAlbum(id);
                if(respuesta!= "El Álbum ha sido eliminado con éxito")
                {
                    Request.Flash("danger", respuesta);
                }
                else
                {
                    Request.Flash("success", respuesta);
                }
                return RedirectToAction("ListarAlbum");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al editar el Álbum", ex.Message);
                throw;
            }

        }
    }
}