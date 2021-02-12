using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Infrastructure
{
    internal class CPFConvention : Convention
    {
        public CPFConvention()
        {
            this.Properties().Where(c => c.PropertyType == typeof(string) && c.Name == "CPF").Configure(c => c.IsRequired().IsFixedLength().HasMaxLength(11));
        }
    }

    internal class CNPJConvention : Convention
    {
        public CNPJConvention()
        {
            
            this.Properties().Where(c => c.PropertyType == typeof(string) && c.Name == "CNPJ").Configure(c => c.IsRequired().IsFixedLength().HasMaxLength(14));
        }
    }

    //internal class HandleConvention : Convention
    //{
    //    public HandleConvention()
    //    {
    //        this.Properties().Where(c => c.PropertyType == typeof(int) && c.Name == "Handle").Configure(c => c.IsKey().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity));
    //    }
    //}



}
