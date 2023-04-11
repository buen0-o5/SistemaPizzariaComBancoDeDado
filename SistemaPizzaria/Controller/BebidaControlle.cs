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
    public class BebidaControlle
    {
        public static void InserirBebidaEstoque()
        {
            try
            {
                using (var connection = new SqlConnection(Conexao.connectionString)) // objeto de conexão 
                {
                    connection.Open();
                    var repository = new Repository<Bebida>(connection);
                    var bebida = new Bebida();
                    Console.SetCursorPosition(3, 12);
                    Console.Write("Cadastrando bebida:");
                    bebida.Bebidas = Console.ReadLine();
                    connection.Insert<Bebida>(bebida);
                    Console.SetCursorPosition(3, 13);
                    Console.Write("Bebida Salva com sucesso!");
                    Thread.Sleep(1000);
                    CoresPadrao();
                    Console.Clear();
                    MenuPrincipal.MenuPrinc();
                }
            }

            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        public static void BuscaBebida()
        {
            try
            {
                using (var connection = new SqlConnection(Conexao.connectionString)) // objeto de conexão 
                {

                    connection.Open(); //abrindo conexão
                    var repository = new Repository<Bebida>(connection);
                    var bebida = repository.Get();
                    
                    Console.WriteLine("|\tBebidas em estoque:");
                    foreach (var item in bebida)
                    {
                        
                        Console.WriteLine($"|\t{item.Id } - { item.Bebidas}");


                    }
                        Limpar();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public static void DeletarBebida()
        {
            try
            {
                using (var connection = new SqlConnection(Conexao.connectionString)) // objeto de conexão 
                {
              

                    connection.Open(); //abrindo conexão
                    var repository = new Repository<Bebida>(connection);
                    Console.SetCursorPosition(3, 12);
                    Console.Write("Informe o Id da bebida que deseja excluir do estoque: ");
                    int item;
                    while(!int.TryParse(Console.ReadLine(), out item))
                    {
                        Console.SetCursorPosition(3, 13);
                        Console.Write("Insira apenas numeros inteiros!");
                    }
                        var bebida = connection.Get<Bebida>(item);
                        connection.Delete<Bebida>(bebida);
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
          
            Console.Write("|\tAperte [0] para limpar ");
            int op = Convert.ToInt32(Console.ReadLine());
            if (op == 0)
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            SubMenuEstoqueBebida.SubMenuBebi();
        }
        public static void CoresPadrao()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
