using Dapper.Contrib.Extensions;
using ProjectBlog.Repositories;
using SistemaPizzaria.Moldels;
using SistemaPizzaria.View;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaPizzaria.Controller
{
    class SobremessaController
    {
        public static void InserirSobremessaEstoque()
        {
            try
            {
                using (var connection = new SqlConnection(Conexao.connectionString)) // objeto de conexão 
                {
                    connection.Open();
                    var repository = new Repository<Sobremessa>(connection);
                    var sobremessa = new Sobremessa();
                    Console.SetCursorPosition(3, 12);
                    Console.Write("Cadastrando sobremessa: ");
                    sobremessa.Sobremessas = Console.ReadLine();
                    connection.Insert<Sobremessa>(sobremessa);
                    Console.SetCursorPosition(3, 13);
                    Console.Write("Sobremessa Salva com sucesso!");
                    Thread.Sleep(1000);
                    Console.Clear();
                    CoresPadrao();
                    MenuPrincipal.MenuPrinc();
                }
            }

            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        public static void BuscaSobremessa()
        {
            try
            {
                using (var connection = new SqlConnection(Conexao.connectionString)) // objeto de conexão 
                {

                    connection.Open(); //abrindo conexão
                    var repository = new Repository<Sobremessa>(connection);
                    var sobremessa = repository.Get();
                    Console.SetCursorPosition(3, 12);
                    Console.WriteLine("|\tSobremessas em estoque: ");
                    foreach (var item in sobremessa)
                    {
                        Console.SetCursorPosition(3, 13);
                        Console.WriteLine($"|\t{item.Id } - { item.Sobremessas}");


                    }
                }
                Limpar();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public static void DeletarSobremessa()
        {
            try
            {
                using (var connection = new SqlConnection(Conexao.connectionString)) // objeto de conexão 
                {


                    connection.Open(); //abrindo conexão
                    var repository = new Repository<Sobremessa>(connection);
                    Console.SetCursorPosition(3, 12);
                    Console.Write("Informe o Id da Sobremessa que deseja excluir do estoque: ");
                    int item;
                    while (!int.TryParse(Console.ReadLine(), out item))
                    {
                        Console.SetCursorPosition(3, 13);
                        Console.Write("Insira apenas numeros inteiros!");
                    }
                    var sobremessa = connection.Get<Sobremessa>(item);
                    connection.Delete<Sobremessa>(sobremessa);
                    Console.SetCursorPosition(3, 14);
                    Console.Write("Pedido excluido com sucesso! ");
                    Thread.Sleep(1000);
                    Console.Clear();
                    CoresPadrao();
                    MenuPrincipal.MenuPrinc();


                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private static void Limpar()
        {
           
            Console.Write("|\tAperte [0] para limpar ");
            int op = Convert.ToInt32(Console.ReadLine());
            if (op == 0)
                Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            SubMenuSobremessa.SubMenuSobre();
        }
        public static void CoresPadrao()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
