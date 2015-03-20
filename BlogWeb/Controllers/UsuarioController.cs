using BlogWeb.DAO;
using BlogWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace BlogWeb.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Form()
        {
            return View();
        }
        private UsuarioDAO usuarioDAO;
        public UsuarioController(UsuarioDAO usuarioDAO)
        {
            this.usuarioDAO = usuarioDAO;
        }

        public ActionResult Adiciona(Usuario usuario)
        {
            try
            {
                WebSecurity.CreateUserAndAccount(usuario.Login, usuario.Password, new { Email = usuario.Email, Nome = usuario.Nome }, false);
                return RedirectToAction("Index");
            }
            catch (MembershipCreateUserException e)
            {
                ModelState.AddModelError("usuario.Invalido", e.Message);
                return View("Form");
            }
        }

        public ActionResult Index()
        {
            IList<Usuario> usuarios = usuarioDAO.Lista();
            return View(usuarios);
        }
    }
}