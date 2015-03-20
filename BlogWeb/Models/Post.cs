using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogWeb.Models
{
    public class Post
    {
        public virtual int Id { get; set; }
        public virtual string Titulo { get; set; }
        public virtual string Conteudo { get; set; }
        public virtual DateTime? DataPublicacao { get; set; }
        public virtual bool Publicado { get; set; }
        public virtual Usuario Autor { get; set; }
    }
}