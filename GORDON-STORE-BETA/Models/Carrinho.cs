using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GORDON_STORE_BETA.Models
{
    public class Carrinho
    {
        public IList<int> pedido;//* vai armazenar os ids dos proodutos
        public long CarrinhoID { get; set; }
        public long? ClienteID;
    }
}