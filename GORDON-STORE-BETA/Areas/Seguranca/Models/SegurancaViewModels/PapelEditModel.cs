using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GORDON_STORE_BETA.Modelo.Sistema;

namespace GORDON_STORE_BETA.Areas.Seguranca.Models
{
    public class PapelEditModel
    {
        public Papel Papel { get; set; }
        public IEnumerable<UsuarioAdm> Membros { get; set; }
        public IEnumerable<UsuarioAdm> NaoMembros { get; set; }
    }
}