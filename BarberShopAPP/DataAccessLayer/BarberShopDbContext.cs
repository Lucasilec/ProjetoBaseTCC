using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BarberShopDbContext : DbContext
    {
        public BarberShopDbContext():base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\moc\Documents\BarberShopDB.mdf;Integrated Security=True;Connect Timeout=30")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configuração Global, que diz que todas as strings serão VARCHAR NOT NULL, ao contrário do padrão que é
            //NVARCHAR NULL
            modelBuilder.Properties().Where(p => p.PropertyType == typeof(string)).Configure(p => p.IsRequired().IsUnicode(false));

            //Pega o projeto atual! (DAL)
            Assembly assembly = Assembly.GetExecutingAssembly();

            //Criar chave única do CPF
            modelBuilder.Entity<Cliente>()
            .HasIndex(a => new { a.CPF}).IsUnique();

            modelBuilder.Conventions.AddFromAssembly(assembly);
            modelBuilder.Configurations.AddFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Servico> Servicos { get; set; }
    }
}
