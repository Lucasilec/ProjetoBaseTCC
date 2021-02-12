using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPresentatoinLayer.Models
{
    public class ClienteQueryViewModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
    }
}