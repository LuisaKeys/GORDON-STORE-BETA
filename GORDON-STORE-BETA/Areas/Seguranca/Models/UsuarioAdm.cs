using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GORDON_STORE_BETA.Areas.Seguranca.Models
{
    public class UsuarioAdm : IdentityUser
    {
        public long Matricula { get; set; }
    }
}