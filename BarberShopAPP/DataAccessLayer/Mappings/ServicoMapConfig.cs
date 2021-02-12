using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappings
{
    internal class ServicoMapConfig : EntityTypeConfiguration<Servico>
    {
        public ServicoMapConfig()
        {
            this.ToTable("SERVICOS");
        }
    }
}
