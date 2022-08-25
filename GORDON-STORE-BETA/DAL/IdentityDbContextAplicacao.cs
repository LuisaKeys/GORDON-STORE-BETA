using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using GORDON_STORE_BETA.Areas.Seguranca.Models;
using System.Data.Entity;

namespace GORDON_STORE_BETA.DAL
{
    public class IdentityDbContextAplicacao : IdentityDbContext<UsuarioAdm>
    {
        public IdentityDbContextAplicacao() : base("Asp_Net_MVC_CS")
        { }
        static IdentityDbContextAplicacao()
        {
            Database.SetInitializer<IdentityDbContextAplicacao>(
            new IdentityDbInit());
        }
        public static IdentityDbContextAplicacao Create()
        {
            return new IdentityDbContextAplicacao();
        }
    }
    public class IdentityDbInit : DropCreateDatabaseIfModelChanges <IdentityDbContextAplicacao>
    {

    }
}