using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPizzaria.Moldels
{
    [Table("[Sobremessa]")]
    public class Sobremessa
    {
        public int Id { get; set; }
        public string Sobremessas { get; set; }
     

    }
}
