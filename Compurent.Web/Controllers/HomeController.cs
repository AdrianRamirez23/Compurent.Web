using Compurent.ADO.Masters.Models;
using Compurent.ADO.ToFront;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Compurent.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            try
            {
                UserAdmin ussr = new UserAdmin();
                ussr = new Front().ValidarSesion(email, password);
                if (!string.IsNullOrEmpty(ussr.NameUser))
                {
                    FormsAuthentication.SetAuthCookie(ussr.id, true);
                    return RedirectToAction("Index","PurchaseDetail");
                }
                else
                {
                    Request.Flash("danger", "No hemos encontrado tus datos de sesión");
                    return RedirectToAction("Index","Home");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al iniciar Sesión", ex.Message);
                throw;
            }
        }
        [HttpPost]
        public ActionResult Register(string id, string pass, string nameUser,string email, string address, string phone)
        {
            try
            {
                UserAdmin ussr = new UserAdmin();
                ussr.id = id;
                ussr.Password = pass;
                ussr.NameUser = nameUser;
                ussr.EmailUser = email;
                ussr.Adress = address;
                ussr.PhoneUser = phone;

                string respuesta = new Front().RegistrarUsuario(ussr);
                if (respuesta=="Registro Exitoso")
                {
                    Request.Flash("success", respuesta);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Request.Flash("danger", respuesta);
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al realizar el registro", ex.Message);
                throw;
            }
        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}