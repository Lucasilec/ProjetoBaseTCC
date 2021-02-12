using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Servico
    {
        public int ID { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSaida { get; set; }
        public double Valor { get; set; }
        public TipoServico TipoServico { get; set; }



        public int ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
