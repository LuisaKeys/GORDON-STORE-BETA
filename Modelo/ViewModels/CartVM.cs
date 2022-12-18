using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Modelo.ViewModels
{
    public class CartVM
    {
        public long ProdutoId { get; set; }

        [Display(Name = "Nome do Produto")]
        public string ProdutoNome { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
        public double Total { get { return Quantidade * Preco; } }
        public string Image { get; set; }
    }
}