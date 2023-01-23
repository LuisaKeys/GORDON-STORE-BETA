using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace GORDON_STORE_BETA.Models.ViewModels
{
    public class CartVM
    {
        public long ProdutoId { get; set; }

        [Display(Name = "Nome do Produto")]
        public string ProdutoNome { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
        public double Total { get { return Quantidade * Preco; } }
        public string UpImgMimeType { get; set; }
        public byte[] UpImg { get; set; }
        public string NomeArquivo { get; set; }
        public long TamanhoArquivo { get; set; }
    }
}