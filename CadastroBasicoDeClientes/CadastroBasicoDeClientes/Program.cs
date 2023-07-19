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
            Contexto contexto = new Contexto();
            var clienteDao = new ClienteDao();

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

            //clienteDao.Inserir(nome, email, uf, data);

            //string queryInsert = string.Format("Insert into Clientes (Nome, email, uf, DataNascimento) Values('{0}', '{1}', '{2}', '{3}')", nome, email, uf, data);
            //contexto.ExecutaComandoSemRetorno(queryInsert);



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

            //clienteDao.Alterar(id, nome, email, uf, data);            


            //==============================Excluir======================================

            //Descomente essas linhas no caso de querer deletar um cadastro

            //Console.Write("Informe o Id desejado para exclusão do cliente: ");
            //int id = Convert.ToInt32(Console.ReadLine());
            //clienteDao.Excluir(id);


            //===============================Listar todos os clientes=====================================

            //SqlDataReader dados = clienteDao.ListarTodos();

            //while (dados.Read())
            //{
            //    Console.WriteLine(string.Format(" CodCliente: {0}, Nome: {1}, Email: {2}, UF: {3}, DataNascimento: {4}", dados["CodCliente"], dados["Nome"], dados["Email"], dados["UF"], dados["DataNascimento"]));
            //}
            SqlDataReader listaClientes = clienteDao.ListarTodos();
            foreach (var cliente in listaClientes)
            {
                Console.WriteLine(string.Format(" CodCliente: {0}, Nome: {1}, Email: {2}, UF: {3}, DataNascimento: {4}", listaClientes["CodCliente"], listaClientes["Nome"], listaClientes["Email"], listaClientes["UF"], listaClientes["DataNascimento"]));
            }

            Console.ReadKey();
        }
    }
}
