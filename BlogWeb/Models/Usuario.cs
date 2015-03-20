using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogWeb.Models
{
    public class Usuario
    {
        public virtual int Id { get; set; }
        public virtual string Login { get; set; }
        public virtual string Password { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Email { get; set; }
    }
}
