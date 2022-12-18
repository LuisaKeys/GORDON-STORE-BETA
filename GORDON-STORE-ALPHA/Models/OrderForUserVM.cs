using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GORDON_STORE_ALPHA.Models
{
    public class OrdersForUserVM
    {
        public long OrderNumber { get; set; }
        public double Total { get; set; }
        public string ProdutoNome { get; set; }

        [DataType(DataType.MultilineText)]
        public Dictionary<string, int> ProdutosAndQty { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}