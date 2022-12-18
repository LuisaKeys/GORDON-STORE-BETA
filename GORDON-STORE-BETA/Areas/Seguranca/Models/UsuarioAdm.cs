using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GORDON_STORE_BETA.Areas.Seguranca.Models
{
    [Table("Funcionarios")]
    public class UsuarioAdm : IdentityUser
    {
        public string Nome { get; set; }        
    }
}