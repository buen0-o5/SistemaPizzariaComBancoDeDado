using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPizzaria.Moldels
{
  
   
    [Table("[Bebida]")]
    public class Bebida
    {
        public int Id { get; set; }
        public string Bebidas{ get; set; }

    }
}
