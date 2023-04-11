using SistemaPizzaria.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPizzaria.View
{
    public class SubMenuPedido
    {
        public static void SubMenuPedid()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
            DrawScreen();
            WriteOptions();
            Console.ReadKey();

        }
        public static void DrawScreen()
        {
            Linhas();
            Colounas();
            Linhas();

        }
        public static void Colounas()
        {
            for (int lines = 0; lines <= 30; lines++)
            {
                Console.Write("|");
                for (int i = 0; i <= 60; i++)
                    Console.Write(" ");

                Console.Write("|");
                Console.Write("\n");

            }

        }

        public static void Linhas()
        {
            Console.Write("+");
            for (int i = 0; i <= 60; i++)
                Console.Write("-");

            Console.Write("+");
            Console.Write("\n");
        }

        public static void WriteOptions()
        {
            Console.SetCursorPosition(3, 2);
            Console.Write("=================Sabores=================");
            Console.SetCursorPosition(3, 3);
            Console.Write(" Esolha a opção que deseja realizar");
            Console.SetCursorPosition(3, 4);
            Console.Write(" [1]Cadastrar Pedido");
            Console.SetCursorPosition(3, 5);
            Console.Write(" [2]Buscar ");
            Console.SetCursorPosition(3, 6);
            Console.Write(" [3]Excluir Pedido");
            Console.SetCursorPosition(3, 7);
            Console.Write(" [4]Voltar para o menu principal");
            Console.SetCursorPosition(3, 8);
            Console.Write(" [5]Sair");
            Console.SetCursorPosition(3, 9);
            Console.Write("-----------------------------");
            Console.SetCursorPosition(3, 10);
            Console.Write("Digite a opção desejada:");
            Console.SetCursorPosition(3, 11);
            Console.Write("Opção: ");
            var menu = short.Parse(Console.ReadLine());
            HandleMenuOption(menu);


        }
        public static void HandleMenuOption(short option)
        {
            switch (option)
            {
                case 1:
                    PedidoController.CriarNovoPedido();
                    break;
                case 2:
                    PedidoController.BuscaPersonalizada();
                    break;
                case 3:
                    PedidoController.DeletarPedido();
                    break;
                case 4:
                    CoresPadrao();
                    MenuPrincipal.MenuPrinc();
                    break;
                case 5:
                    System.Environment.Exit(0);  //sair
                    break;
                default:
                    CoresPadrao();
                    MenuPrincipal.MenuPrinc();
                    break;
            }
        }
        private static void CoresPadrao()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }


    }
}
