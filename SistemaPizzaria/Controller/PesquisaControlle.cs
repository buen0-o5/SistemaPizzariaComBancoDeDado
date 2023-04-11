using Dapper;
using ProjectBlog.Repositories;
using SistemaPizzaria.Moldels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaPizzaria.Controller
{
   public class PesquisaControlle : Repository<Pedido>
    {
        private readonly SqlConnection _connection;
        public PesquisaControlle(SqlConnection connection)
        : base(connection) //chamando o construtor da classe pai
        {
            _connection = connection;
        }
        public List<Pedido> GetWithRoles()
        {
            Console.SetCursorPosition(3,12);
            Console.Write("Digite o Id do cliente que deseja buscar: ") ;
            int result = Convert.ToInt32(Console.ReadLine());
            var query = @"
                     SELECT
                [Pedido].[Nome],
                [Pedido].[Endereco],
                [Pedido].[Descricao],
                [Pizza].[Sabor],
                [Bebida].[Bebidas],
                [Sobremessa].[Sobremessas]
            FROM
                [Pedido]
                LEFT JOIN [Pizza] ON [Pedido].[PizzaId] = [Pizza].[Id]
                LEFT JOIN [Bebida] ON [Pedido].[BebidaId] = [Bebida].[Id]
               LEFT JOIN [Sobremessa] ON [Pedido].[SobremessaId] = [Sobremessa].[Id]
               WHERE
               [Pedido].[Id] =" + result;
            var users = new List<Pedido>();
            // é uma expressão lambda que é passada como parâmetro para o método
            // Query de uma instância de objeto _connection
            var items = _connection.Query<Pedido, Pizza, Bebida,Sobremessa, Pedido>(query, //declara o pedido no final para indicar a classe pai
                (pedido, pizza, bebida, sobremessa) => //é criado uma expressão lambda que é usada para fazer o mapeamento dos
                                                       //resultados das tabelas relacionadas
                                                       //para os tipos Pizza, Bebida e Sobremesa, utilizando a relação
                                                       //de chaves estrangeiras com a tabela de pedidos.
                {
                    var usr = users.FirstOrDefault(x => x.Id == pedido.Id); //é usada para buscar o primeiro
                                                                            //objeto da lista users que satisfaz a
                                                                            //condição especificada, que é comparar o
                                                                            //valor da propriedade Id do objeto User com o
                                                                            //valor da propriedade Id do objeto Pedido.
                                                                            //O método FirstOrDefault retorna o primeiro objeto
                                                                            //que satisfaz a condição, ou null caso nenhum objeto
                                                                            //na lista satisfaça a condição.
                    if (usr == null)
                    {
                        usr = pedido;
                        if (pizza != null && bebida != null && sobremessa != null)
                            usr.Pizza.Add(pizza);
                            usr.Bebida.Add(bebida);
                            usr.Sobremessa.Add(sobremessa);

                        users.Add(usr);

                    }
                    else
                    {
                        usr.Pizza.Add(pizza);
                        usr.Bebida.Add(bebida);
                        usr.Sobremessa.Add(sobremessa);
                    }
                    return pedido;
                }, splitOn: "Sabor, Bebidas, Sobremessas");

            return users;

        }




    }
}
