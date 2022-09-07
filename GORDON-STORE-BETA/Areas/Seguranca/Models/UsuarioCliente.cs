using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GORDON_STORE_BETA.Areas.Seguranca.Models
{
    public class UsuarioCliente : IdentityUser
    {
        public string Sobrenome { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Data de nascimento")]
        public DateTime? DataNascimento { get; set; }
        public long Cpf { get; set; }
    }
}