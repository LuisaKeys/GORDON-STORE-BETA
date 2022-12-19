using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Modelo.Tabelas;

namespace GORDON_STORE_ALPHA.Models.ViewModels
{
    public class CategoriaVM
    {
        public CategoriaVM()
        {

        }
        public CategoriaVM(Categoria row, long? inlineId)
        {
            Id = row.CategoriaId;
            Nome = row.Nome;
        }
        public long Id { get; set; }
        [Required]
        [Display(Name = "Categoria")]
        [StringLength(maximumLength: 50, ErrorMessage = "The category name must be greater than 2 characters", MinimumLength = 2)]
        public string Nome { get; set; }
    }
}
