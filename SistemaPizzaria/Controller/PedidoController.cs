using SistemaPizzaria.Moldels;
using SistemaPizzaria.Controller;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ProjectBlog.Repositories;
using Dapper.Contrib.Extensions;
using System.Threading;
using SistemaPizzaria.View;

namespace SistemaPizzaria.Controller
{
    public class PedidoController
    {
        
        public static void CriarNovoPedido()
        {
            try
            {
                //É usado o using para abrir uma conexão realizar operações e em seguida fecha-la.
               // É passado como parâmetros para o using a criação de um objeto da instancia de um
               // método  da pasta  System.Data.SqlClient, tendo como parâmetros a conexão que foi criada
                using (var connection = new SqlConnection(Conexao.connectionString)) // objeto de conexão 
                {
                    //abrindo a conexão
                    connection.Open();
                    //É um objeto que recebe a instancia da classe reposytory
                    //como esse classe é generica,  é preciso passar a classe que sera refenciada,
                    //e informar o paramentro que faz refencia que faz a conexao, pois  é inicializado no construtor da classe reposytory
                    var repository = new Repository<Pedido>(connection);
                    //É criado um objeto pelo qual vai fazer a ligaçao com os membros da classe pedido para atribuir valoes
                    var pedido = new Pedido();

                    //metodo usado para posicionar a saida na tela
                    Console.SetCursorPosition(3, 12);
                    Console.Write("Informe o nome do cliente: ");
                    //lendo informaçoes da tela e atribuindo esse valor da instancia da classe pedido que faz referencia a 
                    // propriedade nome
                    pedido.Nome = Console.ReadLine();
                    Console.SetCursorPosition(3, 13);
                    Console.Write("Informe o endereço do cliente: ");
                    pedido.Endereco = Console.ReadLine();
                    Console.SetCursorPosition(3, 14);
                    Console.Write("Bebida: ");
                    //convertendo a entrada de dados para int, e atribuinda a int que faz referencia a classe bebida 
                    pedido.BebidaId = Convert.ToInt32(Console.ReadLine());
                    Console.SetCursorPosition(3, 15);
                    Console.Write("Sabor da pizza: ");
                    pedido.PizzaId = Convert.ToInt32(Console.ReadLine());
                    Console.SetCursorPosition(3, 16);
                    Console.Write("Sobremessa: ");
                    pedido.SobremessaId = Convert.ToInt32(Console.ReadLine());
                    Console.SetCursorPosition(3, 17);
                    Console.Write("Descriçao do pedido: ");
                    pedido.Descricao = Console.ReadLine();
                   
                    //Inserindo os valores ao bando
                    connection.Insert<Pedido>(pedido);
                    Console.SetCursorPosition(3, 18);
                    Console.WriteLine("Pedido Salvo com sucesso!");
                    //É um metado que aguarda um determinado tempo antes de continuar a execução de uma tarefa.
                    Thread.Sleep(1000);
                   //Limpando a tela
                    Console.Clear();
                  //chamando o metado para definir as cores padroes da tela
                    CoresPadrao();
                    //chamdno o menu princiapl
                    MenuPrincipal.MenuPrinc();
                }
            }

            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        public static void DeletarPedido()
        {
            try
            {
                using (var connection = new SqlConnection(Conexao.connectionString)) // objeto de conexão 
                {

                    connection.Open(); //abrindo conexão
                    var repository = new Repository<Pedido>(connection);
                    Console.SetCursorPosition(3, 12);
                    Console.Write("Informe o Id do Pedido que deseja excluir:");
                    int item;
                    //É criado um laço de repetiçao para que recebe como parametros a seguinte instruçao:
                    //se o valor recebido na variavel item  for diferente de int (out é uma palavra-chave que faz referencia a
                    // variavel item) entao vai ser criado um lupi que fara a verificaçao para ser aceito apenas numeros inteiros
                    //se caso o valor da tela for aceito ele continua a aplicaçao
                    while (!int.TryParse(Console.ReadLine(), out item))
                    {
                        Console.SetCursorPosition(3, 13);
                        Console.Write("Insira apenas numeros inteiros!");
                    }
                    var pedido = connection.Get<Pedido>(item);
                    //excluindo pedido
                    connection.Delete<Pedido>(pedido);
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
        public static void BuscaPersonalizada()
        {
            try
            {
                using (var connection = new SqlConnection(Conexao.connectionString)) // objeto de conexão 
                {
                    //Leitura e conexao
                    var repository = new PesquisaControlle(connection); //instanciando a classe repositorio para passagem da classe
                    var items = repository.GetWithRoles();

                    //é criado um  foreach para percorrer os itens da classe reposity do metado GetWithRoles que recebe a quey
                    foreach (var item in items)
                    {
                        Console.SetCursorPosition(3, 14);
                        Console.Write("Nome do cliente:");
                        Console.WriteLine($" {item.Nome}");
                        Console.SetCursorPosition(3, 15);
                        Console.Write("Endereço do cliente:");
                        Console.WriteLine($" {item.Endereco}");
                        Console.SetCursorPosition(3, 16);
                        Console.Write("Descriçao do pedido:");
                        Console.WriteLine($" {item.Descricao}");

                        foreach (var pizza in item.Pizza)
                        {
                            Console.SetCursorPosition(3, 17);
                            Console.Write("Sabor da pizza:");
                            Console.WriteLine($" {pizza.Sabor}");
                        }
                        foreach (var bebida in item.Bebida)
                        {
                            Console.SetCursorPosition(3, 18);
                            Console.Write("Bebida: ");
                            Console.WriteLine($" {bebida.Bebidas}");
                        }
                        foreach (var sobremessa in item.Sobremessa)
                        {
                            Console.SetCursorPosition(3, 19);
                            Console.Write("Sobremessa: ");
                            Console.WriteLine($" {sobremessa.Sobremessas}");
                        }
                    }
                    Limpar();
                }
            }

            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        private static void Limpar()
        {
            Console.SetCursorPosition(3, 20);
            Console.Write("Aperte [0] para limpar ");
            int op = Convert.ToInt32(Console.ReadLine());
            if (op == 0)
                Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            SubMenuPedido.SubMenuPedid();
        }
        public static void CoresPadrao()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}

