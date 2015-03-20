using BlogWeb.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogWeb.Controllers
{
    public class MenuController : Controller
    {
        private UsuarioDAO usuarioDAO;
        public MenuController(UsuarioDAO usuarioDAO)
        {
            this.usuarioDAO = usuarioDAO;
        }
        public ActionResult Index()
        {
            ViewBag.Autores = usuarioDAO.Lista();
            return PartialView();
        }
    }
}