using BlogWeb.Infra;
using BlogWeb.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogWeb.DAO
{
    public class PostDAO
    {
        private ISession session;
        public PostDAO(ISession session)
        {
            this.session = session;
        }

        public void Adiciona(Post post)
        {
            ITransaction tx = session.BeginTransaction();
            session.Save(post);
            tx.Commit();
        }
        public Post BuscaPorId(int id)
        {
            return session.Get<Post>(id);
        }
        public void Remove(Post post)
        {
            ITransaction tx = session.BeginTransaction();
            session.Delete(post);
            tx.Commit();
        }
        public void Atualiza(Post post)
        {
            ITransaction tx = session.BeginTransaction();
            session.Merge(post);
            tx.Commit();
        }
        public IList<Post> Lista()
        {
            string hql = "select p from Post p";
            IQuery query = session.CreateQuery(hql);
            return query.List<Post>();
        }

        public IList<Post> ListaPublicados()
        {
            string hql = "select p from Post p where p.Publicado = true " +
            "order by p.DataPublicacao desc";
            IQuery query = session.CreateQuery(hql);
            return query.List<Post>();
        }

        public IList<Post> ListaPublicadosDoAutor(string nome)
        {
            String hql = "select p from Post p where " +
            "p.Publicado = true and p.Autor.Nome = :nome";
            IQuery query = session.CreateQuery(hql);
            query.SetParameter("nome", nome);
            return query.List<Post>();
        }
    }
}