using BlogWeb.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogWeb.Mapeamentos
{
    public class UsuarioMapping : ClassMap<Usuario>
    {
        public UsuarioMapping()
        {
            Id(usuario => usuario.Id).GeneratedBy.Identity();
            Map(usuario => usuario.Login);
            Map(usuario => usuario.Password);
            Map(usuario => usuario.Email);
            Map(usuario => usuario.Nome);
        }
    }
}