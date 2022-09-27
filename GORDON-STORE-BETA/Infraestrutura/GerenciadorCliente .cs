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
    public class GerenciadorCliente : UserManager<UsuarioCliente>
    {
        public GerenciadorCliente(IUserStore<UsuarioCliente> store) : base(store)
        { }
        public static GerenciadorCliente Create(
        IdentityFactoryOptions<GerenciadorCliente> options, IOwinContext context)
        {
            IdentityDbContextAplicacao db =
            context.Get<IdentityDbContextAplicacao>();
            GerenciadorCliente manager = new GerenciadorCliente(
            new UserStore<UsuarioCliente>(db));
            return manager;
        }
    }
}