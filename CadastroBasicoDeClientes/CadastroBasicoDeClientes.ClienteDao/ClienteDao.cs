using CadastroBasicoDeClientes.Dominio;
using CadastroBasicoDeClientes.Dominio.Contrato;
using CadastroBasicoDeClientes.Repositorio;
using CadastroBasicoDeClientes.RepositorioADO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroBasicoDeClientes.Cliente_Dao
{
    public class ClienteDao
    {
        private readonly IRepositorio<Cliente> repositorio;

        public ClienteDao(IRepositorio<Cliente> repo)
        {
            repositorio = repo;
        }
        public void Salvar(Cliente cliente)
        {
            repositorio.Salvar(cliente);
        }

        public void Excluir(Cliente  cliente)
        {
            repositorio.Excluir(cliente);
        }

        public IEnumerable<Cliente> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public Cliente ListarPorId(string id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
