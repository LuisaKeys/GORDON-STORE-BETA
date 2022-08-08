using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GORDON_STORE_BETA.Models
{
    public class Produto
    {

        [Display(Name = "Código")]
        public long ProdutoId { get; set; }
  
        
        public string Nome { get; set; }
        [Display(Name = "Preço")]
        public double Preco { get; set; }
        [Display(Name = "Quantidade")]
        public int Qtd { get; set; }
        
        public long? CategoriaId { get; set; }
        
        public long? EstudioId { get; set; }
        [Display(Name = "Categoria")]
        public Categoria Categoria { get; set; }
        [Display(Name = "Estúdio")]
        public Estudio Estudio { get; set; }
    }
}