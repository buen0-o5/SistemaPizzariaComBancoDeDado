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
    class PizzaController
    {
        public static void InserirSaborPizza()
        {
            try
            {
                using (var connection = new SqlConnection(Conexao.connectionString)) // objeto de conexão 
                {
                    connection.Open();
                    var repository = new Repository<Pizza>(connection);
                    var pizza = new Pizza();
                    Console.SetCursorPosition(3, 12);
                    Console.Write("Cadastrando Pizza:");
                    pizza.Sabor = Console.ReadLine();
                    connection.Insert<Pizza>(pizza);
                    Console.SetCursorPosition(3, 13);
                    Console.Write("Novo sabor de pizza salvo com sucesso!");
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
        public static void BuscaPizza()
        {
            try
            {
                using (var connection = new SqlConnection(Conexao.connectionString)) // objeto de conexão 
                {

                    connection.Open(); //abrindo conexão
                    var repository = new Repository<Pizza>(connection);
                    var pizza = repository.Get();
                    Console.WriteLine("|\tSabores de pizzas cadastrados");
                    foreach (var item in pizza)
                    {
                        
                        Console.WriteLine($"|\t{item.Id } - { item.Sabor}");
                    }
                }
                Limpar();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public static void DeletarSaborPizza()
        {
            try
            {
                using (var connection = new SqlConnection(Conexao.connectionString)) // objeto de conexão 
                {

                    connection.Open(); //abrindo conexão
                    var repository = new Repository<Pizza>(connection);
                    Console.SetCursorPosition(3, 12);
                    Console.Write("Informe o Id do sabor de Pizza que deseja excluir do cardapio: ");
                    int item;
                    while (!int.TryParse(Console.ReadLine(), out item))
                    {
                        Console.SetCursorPosition(3, 13);
                        Console.Write("Insira apenas numeros inteiros!");
                    }
                    var pizza = connection.Get<Pizza>(item);
                    connection.Delete<Pizza>(pizza);
                    Console.SetCursorPosition(3, 14);
                    Console.Write("Pedido excluido com sucesso!");
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
        public static void Limpar()
        {
            ;
            Console.Write("|\tAperte [0] para limpar ");
            int op = Convert.ToInt32(Console.ReadLine());
            if (op == 0)
               Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            SubMenuAdicionarPizza.SubMenuPizza();
        }
        public static void CoresPadrao()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }





    }
}