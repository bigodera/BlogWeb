using BlogWeb.DAO;
using BlogWeb.Models;
using BlogWeb.ViewModels;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogWeb.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private PostDAO dao;
        private UsuarioDAO usuarioDAO;
        public PostController(PostDAO dao, UsuarioDAO usuarioDAO)
        {
            this.dao = dao;
            this.usuarioDAO = usuarioDAO;
        }

        
        public ActionResult Index()
        {
            IList<Post> posts = dao.Lista();
            return View(posts);
        }

        public ActionResult Form()
        {
            ViewBag.Usuarios = usuarioDAO.Lista();
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(PostModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Post post = viewModel.CriaPost();
                dao.Adiciona(post);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Usuarios = usuarioDAO.Lista();
                return View("Form", viewModel);
            }
        }

        public ActionResult Remove(int id)
        {
            Post post = dao.BuscaPorId(id);
            dao.Remove(post);
            return RedirectToAction("Index");
        }

        public ActionResult Visualiza(int id)
        {
            Post post = dao.BuscaPorId(id);
            PostModel viewModel = new PostModel(post);
            ViewBag.Usuarios = usuarioDAO.Lista();
            return View(viewModel);
        }

        public ActionResult Altera(PostModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Post post = viewModel.CriaPost();
                dao.Atualiza(post);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Usuarios = usuarioDAO.Lista();
                return View("Visualiza", viewModel);
            }
        }

        public ActionResult Publica(int id)
        {
            Post post = dao.BuscaPorId(id);
            post.Publicado = true;
            post.DataPublicacao = DateTime.Now;
            dao.Atualiza(post);
            return RedirectToAction("Index");
        }
    }
}