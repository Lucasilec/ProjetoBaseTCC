using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappings
{

    internal class ClienteMapConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteMapConfig()
        {
            this.ToTable("CLIENTES");
            this.Property(p => p.Email).HasMaxLength(70);
            this.Property(p => p.Nome).HasMaxLength(50);
            this.Property(p => p.Telefone).HasMaxLength(15);
            //Exemplo de API FLUENT
            //Carro carro = new Carro().SetCV(220).SetModelo("AUDI A4");

            Carro c = Carro.GetInstance();
            Carro c2 = Carro.GetInstance();
            Carro c3 = Carro.GetInstance();
            Carro c4 = Carro.GetInstance();



        }
    }



    class Carro
    {
        //Singleton
        private Carro()
        {

        }

        private static Carro _instance;

        public static Carro GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Carro();
            }
            return _instance;
        }

        public string Modelo { get; private set; }
        public int CV { get; private set; }

        public Carro SetCV(int cv)
        {
            this.CV = cv;
            return this;
        }

        public Carro SetModelo(string modelo)
        {
            this.Modelo = modelo;
            return this;
        }
    }
}
