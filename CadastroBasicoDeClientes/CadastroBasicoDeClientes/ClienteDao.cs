using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroBasicoDeClientes
{
    public class ClienteDao
    {
        private Contexto contexto;

        public ClienteDao()
        {
            contexto = new Contexto();
        }

        private void Inserir(Cliente cliente) 
        {
            var strQuery = string.Format("Insert into Clientes(Nome, Email, UF, DataNascimento) values('{0}', '{1}', '{2}', '{3}')", cliente.Nome, cliente.Email, cliente.UF, cliente.DataNascimento);
            contexto.ExecutaComandoSemRetorno(strQuery);
        }

        private void Alterar(Cliente cliente) 
        {
            var strQuery = string.Format("Update Clientes set Nome='{0}', Email='{1}', UF='{2}', DataNascimento='{3}' Where CodCliente={4}", cliente.Nome, cliente.Email, cliente.UF, cliente.DataNascimento, cliente.Id);
            contexto.ExecutaComandoSemRetorno(strQuery);
        }

        public void Excluir(int id) 
        {
            var strQuery = string.Format("Delete from Clientes where CodCliente={0}", id);
            contexto.ExecutaComandoSemRetorno(strQuery);
        }

        public List<Cliente> ListarTodos() 
        {
            var listaDeClientes = new List<Cliente>();
            var strQuery = "Select * from Clientes";
            SqlDataReader dados = contexto.ExecutaComandoComRetorno(strQuery);
            while (dados.Read())
            {
                var cliente = new Cliente
                {
                    Id = Convert.ToInt32(dados["CodCliente"]),
                    Nome = Convert.ToString(dados["Nome"]),
                    Email = Convert.ToString(dados["Email"]),
                    UF = Convert.ToString(dados["UF"]),
                    DataNascimento = Convert.ToDateTime(dados["DataNascimento"])
                };
                listaDeClientes.Add(cliente);
            }
            return listaDeClientes;
        }

        //Esse método insere ou altera, se na classe Program for passado um Id ele altera, se não ele insere
        public void Salvar(Cliente cliente) 
        {
            if (cliente.Id > 0)
                Alterar(cliente);
            else
                Inserir(cliente);
        }
    }
}
