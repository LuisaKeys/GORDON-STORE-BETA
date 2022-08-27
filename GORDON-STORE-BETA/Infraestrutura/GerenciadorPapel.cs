using GORDON_STORE_BETA.Areas.Seguranca.Models;
using GORDON_STORE_BETA.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GORDON_STORE_BETA.Infraestrutura
{
    public class GerenciadorPapel : RoleManager<Papel>, IDisposable
    {
        public GerenciadorPapel(RoleStore<Papel> store) : base(store)
        {
        }
        public static GerenciadorPapel Create(IdentityFactoryOptions
        <GerenciadorPapel> options, IOwinContext context)
        {
            return new GerenciadorPapel(new RoleStore<Papel>
            (context.Get<IdentityDbContextAplicacao>()));
        }
        
    }
}