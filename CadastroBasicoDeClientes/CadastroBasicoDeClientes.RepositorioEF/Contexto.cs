using CadastroBasicoDeClientes.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroBasicoDeClientes.RepositorioEF
{
    public class Contexto : DbContext
    {
        public Contexto()
            : base("minhaConnectionString")
        {

        }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().Property(x => x.Nome).IsRequired().HasColumnType("varchar").HasMaxLength(100);
            modelBuilder.Entity<Cliente>().Property(x => x.Email).IsRequired().HasColumnType("varchar").HasMaxLength(100);
            modelBuilder.Entity<Cliente>().Property(x => x.UF).IsRequired().HasColumnType("char").HasMaxLength(2);
            modelBuilder.Entity<Cliente>().Property(x => x.DataNascimento).IsRequired().HasColumnType("Date");
        }
    }
}
