using Compurent.ADO.Masters.Models;
using Compurent.ADO.ToFront;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Compurent.Web.Controllers
{
    [Authorize]
    public class PurchaseDetailController : Controller
    {
        // GET: PurchaseDetail 
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                List<PurchaseDetail> details= new  List<PurchaseDetail>();
                details = new Front().ListaPedidos(User.Identity.Name);

                List<Models.PurchaseDetail> dits = new List<Models.PurchaseDetail>();
                foreach(PurchaseDetail detail in details)
                {
                    Models.PurchaseDetail dit = new Models.PurchaseDetail();
                    dit.Client_id = detail.Client_id;
                    dit.Album_id = detail.Album_id;
                    dit.Total = detail.Total;
                    dit.id = detail.id;
                    dits.Add(dit);
                }
                return View(dits);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
        }
        public ActionResult CrearPedido()
        {
            List<Album> alb = new List<Album>();
            alb = new Front().ListarAlbum();

            List<SelectListItem> items = alb.ConvertAll(al =>
            {
                return new SelectListItem()
                {
                    Text = al.Name,
                    Value = Convert.ToString(al.id),
                    Selected = false
                };
            });

            ViewBag.items = items;
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CrearPedido(Models.PurchaseDetail detail)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    detail.Client_id = User.Identity.Name;
                    PurchaseDetail det = new PurchaseDetail();
                    det.Client_id = detail.Client_id;
                    det.Album_id = detail.Album_id;
                    det.Total = detail.Total;

                    new Front().CrearPedido(det);
                    return RedirectToAction("Index", "PurchaseDetail");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}