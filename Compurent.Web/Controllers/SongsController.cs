using Compurent.ADO.Masters.Models;
using Compurent.ADO.ToFront;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Compurent.Web.Controllers
{
    public class SongsController : Controller
    {
        // GET: Song's List
        public ActionResult Index()
        {
            try
            {
                List<Songs> songs = new List<Songs>();
                songs = new Front().ListarCanciones();

                List<Models.Songs> Song = new List<Models.Songs>();
                foreach(Songs song in songs)
                {
                    Models.Songs sgs = new  Models.Songs();
                    sgs.id = song.id;
                    sgs.Name = song.Name;
                    sgs.Album_id = song.Album_id;
                    Song.Add(sgs);
                }
                return View(Song);
            }
            catch (Exception e)
            {
                Request.Flash("danger", e.Message);
                throw;
            }
        }
        public ActionResult AgregarCancion()
        {
            try
            {
                List<Album> alb = new List<Album>();
                alb = new Front().ListarAlbum();

                List<SelectListItem> items = alb.ConvertAll(al=>
                {
                    return new SelectListItem()
                    {
                        Text = al.Name,
                        Value=Convert.ToString(al.id),
                        Selected=false
                    };
                });

                ViewBag.items = items;
                return View();
            }
            catch (Exception ex)
            {
                Request.Flash("danger", ex.Message);
                throw;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarCancion(Compurent.Web.Models.Songs song)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                Songs sng = new Songs();
                sng.Name = song.Name;
                sng.Album_id = song.Album_id;
                new Front().CrearCancion(sng);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                Request.Flash("danger", ex.Message);
                return View();
            }
        }
        public ActionResult EditarCancion(int Id)
        {
            try
            {
                Songs song = new Songs();
                song = new Front().BuscarCancion(Id);
                Models.Songs sog = new Models.Songs();
                sog.id = song.id;
                sog.Name = song.Name;

                List<Album> alb = new List<Album>();
                alb = new Front().ListarAlbum();

                List<SelectListItem> items = alb.ConvertAll(al =>
                {
                    return new SelectListItem()
                    {
                        Text = al.Name,
                        Value = Convert.ToString(al.id),
                        Selected = true
                    };
                });

                ViewBag.items = items;
                return View(sog);

            }
            catch (Exception e)
            {
                Request.Flash("danger", e.Message);
                throw;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarCancion(Models.Songs song)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                Songs songs = new Songs();
                songs.id = song.id;
                songs.Name = song.Name;
                songs.Album_id = song.Album_id;
                new Front().EditarCancion(songs);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Request.Flash("danger", e.Message);
                throw;
            }
        }
        public ActionResult EliminarCancion(int id)
        {
            try
            {
                string respuesta = new Front().EliminarCancion(id);
                if (respuesta != "La Cacnión ha sido eliminada con éxito")
                {
                    Request.Flash("danger", respuesta);
                }
                else
                {
                    Request.Flash("success", respuesta);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al eliminar la canción", ex.Message);
                throw;
            }

        }
    }
}