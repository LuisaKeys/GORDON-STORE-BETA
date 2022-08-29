using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Modelo.Tabelas;

namespace Modelo.Cadastro
{
    public class Produto
    {
       
        [DisplayName("Id")]
        public long? ProdutoId { get; set; }
        [StringLength(100, ErrorMessage = "O nome do produto precisa ter no mínimo 10 caracteres", MinimumLength = 10)]
        [Required(ErrorMessage = "Informe o nome do produto")]
        public string Nome { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Data de Cadastro")]
        [Required(ErrorMessage = "Informe data de cadastro do produto")]
        public DateTime? DataCadastro { get; set; }
        [DisplayName("Preço")]
        [Range(1, Double.PositiveInfinity)]
        [Required(ErrorMessage = "O preço deve conter um valor válido")]
        public float Preco { get; set; }
        [DisplayName("Quantidade")]
        public int Qtd { get; set; }
        [DisplayName("Categoria")]
        public long? CategoriaId { get; set; }
        [DisplayName("Estúdio")]
        public long? EstudioId { get; set; }
        public Categoria Categoria { get; set; }
        public Estudio Estudio { get; set; }
    }
}