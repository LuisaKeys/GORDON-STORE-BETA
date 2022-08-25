using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GORDON_STORE_BETA.Areas.Seguranca.Models
{
    public class UsuarioViewModel
    {
        public string Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public long Matricula { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}