using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using GORDON_STORE_BETA.Areas.Seguranca.Models;
using GORDON_STORE_BETA.DAL;

namespace GORDON_STORE_BETA.Infraestrutura
{
    public class GerenciadorUsuario : UserManager<UsuarioAdm>
    {
        public GerenciadorUsuario(IUserStore<UsuarioAdm> store) : base(store)
        { }
        public static GerenciadorUsuario Create(
        IdentityFactoryOptions<GerenciadorUsuario> options, IOwinContext context)
        {
            IdentityDbContextAplicacao db =
            context.Get<IdentityDbContextAplicacao>();
            GerenciadorUsuario manager = new GerenciadorUsuario(
            new UserStore<UsuarioAdm>(db));
            return manager;
        }
    }
}