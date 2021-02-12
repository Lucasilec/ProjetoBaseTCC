using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Message
{
    public class Response
    {
        public string Mensagem { get; set; }
        public bool Sucesso { get; set; }
        public string Exception { get; set; }
    }
}
