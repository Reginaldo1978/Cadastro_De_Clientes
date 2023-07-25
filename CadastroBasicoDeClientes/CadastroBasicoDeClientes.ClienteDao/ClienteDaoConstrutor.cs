using CadastroBasicoDeClientes.RepositorioADO;
using CadastroBasicoDeClientes.RepositorioEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroBasicoDeClientes.Cliente_Dao
{
    public class ClienteDaoConstrutor
    {
        public static ClienteDao ClienteDaoADO() 
        {
            return new ClienteDao(new ClienteDaoRepositorioADO());
        }

        public static ClienteDao ClienteDaoEF() 
        {
            return new ClienteDao(new ClienteDaoRepositorioEF());
        }
    }
}
