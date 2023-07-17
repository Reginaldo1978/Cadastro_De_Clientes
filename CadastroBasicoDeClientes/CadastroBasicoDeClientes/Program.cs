using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroBasicoDeClientes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Não esqueça de trocar o Data Source da ConnectionString atual pelo o da sua máquina 
            SqlConnection minhaConexao = new SqlConnection(@"Data Source=REGINALDO-PC\SQLSERVER2022;Initial Catalog=BD_Loja;Integrated Security=SSPI;");
            minhaConexao.Open();

            //==================================Cadastrar======================================

            //descomente as linhas abaixo para um novo cadastro


            //Console.Write("Informe o nome do cliente: ");
            //string nome = Console.ReadLine();

            //Console.Write("Informe o email do cliente: ");
            //string email = Console.ReadLine();

            //Console.Write("Informe a UF do cliente: ");
            //string uf = Console.ReadLine();

            //Console.Write("Informe a data de nascimento do clinte: ");
            //string data = Console.ReadLine();

            //string queryInsert = string.Format("Insert into Clientes (Nome, email, uf, DataNascimento) Values('{0}', '{1}', '{2}', '{3}')", nome, email, uf, data);
            //SqlCommand comandoCreate = new SqlCommand(queryInsert, minhaConexao);
            //comandoCreate.ExecuteNonQuery();



            //==============================Alterar======================================

            //Descomente as linhas abaixo no caso de querer alterar uma informação

            //Console.Write("Informe o Id desejado para alteração: ");
            //int id = Convert.ToInt32(Console.ReadLine());

            //Console.Write("Informe o nome do cliente: ");
            //string nome = Console.ReadLine();

            //Console.Write("Informe o email do cliente: ");
            //string email = Console.ReadLine();

            //Console.Write("Informe a UF do cliente: ");
            //string uf = Console.ReadLine();

            //Console.Write("Informe a data de nascimento do clinte: ");

            //string data = Console.ReadLine();

            //string queryUpdate = string.Format("Update Clientes set Nome='{0}', Email='{1}', UF='{2}', DataNascimento='{3}' where CodCliente={4}", nome, email, uf, data, id);
            //SqlCommand comandoUpdate = new SqlCommand(queryUpdate, minhaConexao);
            //comandoUpdate.ExecuteNonQuery();


            //==============================Excluir======================================

            //Descomente essas linhas no caso de querer deletar um cadastro

            //Console.Write("Informe o Id desejado para exclusão do cliente: ");
            //int id = Convert.ToInt32(Console.ReadLine());
            //string queryDelete = string.Format("Delete from Clientes where CodCliente = {0}", id);
            //SqlCommand comandoDelete = new SqlCommand(queryDelete, minhaConexao);
            //comandoDelete.ExecuteNonQuery();


            //===============================Listar todos os clientes=====================================

            string strSelect = "Select * from Clientes";
            SqlCommand comandoSelect = new SqlCommand(strSelect, minhaConexao);
            SqlDataReader dados = comandoSelect.ExecuteReader();

            while (dados.Read())
            {
                Console.WriteLine(string.Format(" CodCliente: {0}, Nome: {1}, Email: {2}, UF: {3}, DataNascimento: {4}", dados["CodCliente"], dados["Nome"], dados["Email"], dados["UF"], dados["DataNascimento"]));
            }


            Console.ReadKey();
        }
    }
}
