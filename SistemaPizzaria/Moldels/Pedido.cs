using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPizzaria.Moldels
{
    [Table("[Pedido]")] //Metadado que informa o nome que deve ser usado na query(sendo necessario pois na busca o dapper
                        //passa para o plural)
    public class Pedido
    {
        public Pedido()
        {
            //sempre que criar uma lista e necessario inicializa-la antes
            Pizza = new List<Pizza>();
            Bebida = new List<Bebida>();
            Sobremessa = new List<Sobremessa>();
        }

        //propriedades que fazem referencia ao objeto pedido e que fazem ligaçao com o bando 
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Descricao { get; set; }
        public int BebidaId { get; set; }
        public int PizzaId { get; set; }
        public int SobremessaId { get; set; }
        [Write(false)] //somente leitura 
        public IList<Pizza> Pizza { get; set; } //lista usada na funçao para instanciar o objeto de outra classse
        [Write(false)]
        public IList<Bebida> Bebida { get; set; }
        [Write(false)]
        public IList<Sobremessa> Sobremessa { get; set; }



    }
}
