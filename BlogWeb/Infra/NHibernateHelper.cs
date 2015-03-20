using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BlogWeb.Infra
{
    public class NHibernateHelper
    {
        private static ISessionFactory factory = CriaFactory();

        private static ISessionFactory CriaFactory()
        {
            Configuration cfg = new Configuration();
            cfg.Configure();
            return Fluently.Configure(cfg)
            .Mappings(x => { x.FluentMappings.AddFromAssembly(
                            Assembly.GetExecutingAssembly());
                           } ).BuildSessionFactory();
        }

        public static ISession AbreSession()
        {
            return factory.OpenSession();
        }
    }
}