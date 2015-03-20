using BlogWeb.DAO;
using BlogWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogWeb.Controllers
{
    public class HomeController : Controller
    {
        private PostDAO postDAO;

        public HomeController(PostDAO postDAO)
        {
            this.postDAO = postDAO;
        }

        // GET: Home
        public ActionResult Index()
        {
            IList<Post> posts = postDAO.ListaPublicados();
            return View(posts);
        }
    }
}