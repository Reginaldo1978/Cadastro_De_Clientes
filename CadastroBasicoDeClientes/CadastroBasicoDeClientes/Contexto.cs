using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroBasicoDeClientes
{
    public class Contexto : IDisposable
    {
        private readonly SqlConnection minhaConexao;

        public Contexto()
        {
            minhaConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["minhaConnectionString"].ConnectionString);
            minhaConexao.Open();
        }

        public void ExecutaComandoSemRetorno(string strQuery) 
        {
            var cmdComando = new SqlCommand(strQuery, minhaConexao);
            cmdComando.ExecuteNonQuery();
        }

        public SqlDataReader ExecutaComandoComRetorno(string strQuery) 
        {
            var cmdComando = new SqlCommand(strQuery, minhaConexao);
            return cmdComando.ExecuteReader();
        }
        
        public void Dispose()
        {
            if (minhaConexao.State == ConnectionState.Open) 
            {
                minhaConexao.Close();
            }
        }
    }
}
