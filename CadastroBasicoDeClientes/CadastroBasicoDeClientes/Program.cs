using CadastroBasicoDeClientes.Dominio;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using CadastroBasicoDeClientes.Cliente_Dao;

namespace CadastroBasicoDeClientes
{
    class Program
    {
        static void Main(string[] args)
        {
            var clienteDao = new ClienteDao();

            //==================================Cadastrar======================================

            //descomente as linhas abaixo para um novo cadastro

            Console.Write("Informe o nome do cliente: ");
            string nome = Console.ReadLine();

            Console.Write("Informe o email do cliente: ");
            string email = Console.ReadLine();

            Console.Write("Informe a UF do cliente: ");
            string uf = Console.ReadLine();

            Console.Write("Informe a data de nascimento do clinte: ");
            string data = Console.ReadLine();

            var cliente = new Cliente
            {
                Nome = nome,
                Email = email,
                UF = uf,
                DataNascimento = Convert.ToDateTime(data)
            };

            //Para alteração, descomente a linha abaixo, digite o Id do cliente que deseja alterar
            //cliente.Id = 13; 
            clienteDao.Salvar(cliente); 

            //==============================Excluir======================================

            //Descomente essas linhas no caso de querer deletar um cadastro

            //Console.Write("Informe o Id desejado para exclusão do cliente: ");
            //int id = Convert.ToInt32(Console.ReadLine());
            //clienteDao.Excluir(id);

            //===============================Listar todos os clientes=====================================

            foreach (var cli in clienteDao.ListarTodos())
            {
                Console.WriteLine(string.Format(" CodCliente: {0}, Nome: {1}, Email: {2}, UF: {3}, DataNascimento: {4}", cli.Id, cli.Nome, cli.Email, cli.UF, cli.DataNascimento));
            }
            Console.ReadKey();
        }
    }
}
