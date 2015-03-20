using BlogWeb.Infra;
using BlogWeb.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogWeb.DAO
{
    public class UsuarioDAO
    {
        private ISession session;
        public UsuarioDAO(ISession session)
        {
            this.session = session;
        }

        public void Adiciona(Usuario usuario)
        {
            ITransaction tx = session.BeginTransaction();
            session.Save(usuario);
            tx.Commit();
        }

        public IList<Usuario> Lista()
        {
            String hql = "select u from Usuario u";
            IQuery query = session.CreateQuery(hql);
            return query.List<Usuario>();
        }

        public Usuario Busca(string login, string senha)
        {
            string hql = "select u from Usuario u where " +
            "u.Login = :login and u.Password = :senha";
            IQuery query = session.CreateQuery(hql);
            query.SetParameter("login", login);
            query.SetParameter("senha", senha);
            return query.UniqueResult<Usuario>();
        }
    }
}