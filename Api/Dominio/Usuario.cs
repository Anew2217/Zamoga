using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Rol { get; set; }
        public string Pass { get; set; }
    }
}