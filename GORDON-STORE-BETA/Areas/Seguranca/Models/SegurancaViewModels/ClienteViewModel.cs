using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GORDON_STORE_BETA.Areas.Seguranca.Models.SegurancaViewModels
{
    public class ClienteViewModel
    {
        public string Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Rua { get; set; }
        [Required]
        public string Numero { get; set; }
        [Required]
        public string Complemento { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Data de nascimento")]
        public DateTime? DataNascimento { get; set; }
        [Required]
        public long Cpf { get; set; }
        [Required]
        public long Telefone { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}