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

        public void Inserir(string nome, string email, string uf, string data) 
        {
            var strQuery = string.Format("Insert into Clientes(Nome, Email, UF, DataNascimento) values('{0}', '{1}', '{2}', '{3}')", nome, email, uf, data);
            contexto.ExecutaComandoSemRetorno(strQuery);
        }

        public void Alterar(int id, string nome, string email, string uf, string data) 
        {
            var strQuery = string.Format("Update Clientes set Nome='{0}', Email='{1}', UF='{2}', DataNascimento='{3}' Where CodCliente={4}", nome, email, uf, data, id);
            contexto.ExecutaComandoSemRetorno(strQuery);
        }

        public void Excluir(int id) 
        {
            var strQuery = string.Format("Delete from Clientes where CodCliente={0}", id);
            contexto.ExecutaComandoSemRetorno(strQuery);
        }

        public SqlDataReader ListarTodos() 
        {
            var strquery = "Select * from Clientes";
            return contexto.ExecutaComandoComRetorno(strquery);
        }
    }
}
