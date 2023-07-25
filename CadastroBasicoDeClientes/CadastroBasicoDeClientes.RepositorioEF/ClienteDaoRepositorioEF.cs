using CadastroBasicoDeClientes.Dominio;
using CadastroBasicoDeClientes.Dominio.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroBasicoDeClientes.RepositorioEF
{
    public class ClienteDaoRepositorioEF : IRepositorio<Cliente>
    {
        private readonly Contexto contexto;

        public ClienteDaoRepositorioEF()
        {
            contexto = new Contexto();
        }
        public void Salvar(Cliente entidade)
        {
            if(entidade.Id > 0) 
            {
                var clienteAlterar = contexto.Clientes.First(x => x.Id == entidade.Id);
                clienteAlterar.Nome = entidade.Nome;
                clienteAlterar.Email = entidade.Email;
                clienteAlterar.UF = entidade.UF;
                clienteAlterar.DataNascimento = entidade.DataNascimento;
            }
            else
            {
                contexto.Clientes.Add(entidade);
            }
            contexto.SaveChanges();
        }
        public void Excluir(Cliente entidade)
        {
            var clienteExcluir = contexto.Clientes.First(x => x.Id == entidade.Id);
            contexto.Set<Cliente>().Remove(clienteExcluir);
            contexto.SaveChanges();
        }

        public Cliente ListarPorId(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return contexto.Clientes.First(x => x.Id == idInt);
        }

        public IEnumerable<Cliente> ListarTodos()
        {
            return contexto.Clientes;
        }       
    }
}
