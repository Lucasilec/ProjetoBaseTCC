using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPresentatoinLayer.Models
{
    public class ClienteInsertViewModel
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }

    }
}