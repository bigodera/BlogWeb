using BlogWeb.DAO;
using BlogWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogWeb.Controllers
{
    public class BuscaController : Controller
    {
        private PostDAO postDAO;
        public BuscaController(PostDAO postDAO)
        {
            this.postDAO = postDAO;
        }
        public ActionResult BuscaPorAutor(string nome)
        {
            IList<Post> resultado = postDAO.ListaPublicadosDoAutor(nome);
            return View(resultado);
        }
    }
}
