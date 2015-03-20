using BlogWeb.DAO;
using BlogWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace BlogWeb.Controllers
{
    public class LoginController : Controller
    {
        private UsuarioDAO usuarioDAO;
        public LoginController(UsuarioDAO usuarioDAO)
        {
            this.usuarioDAO = usuarioDAO;

            if (!WebSecurity.Initialized)
            {
                try
                {
                    WebSecurity.InitializeDatabaseConnection(
                    "blog", "Usuario", "Id", "Login", true);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autentica(Usuario usuario)
        {
            if(WebSecurity.Login(usuario.Login, usuario.Password))
            {
                return RedirectToAction("index", "post");
            }
            else
            {
                ModelState.AddModelError("login.Invalido",
                "Login ou senha incorretos");
                return View("Index");
            }
        }

        public ActionResult Logout()
        {
            // faz o logout
            WebSecurity.Logout();
            // e redireciona para o formulário de login
            return RedirectToAction("Index");
        }
    }
}