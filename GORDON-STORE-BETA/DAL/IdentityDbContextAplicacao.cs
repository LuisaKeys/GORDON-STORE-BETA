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
        public IdentityDbContextAplicacao() : base("GORDON_STORE")
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

        public System.Data.Entity.DbSet<GORDON_STORE_BETA.Areas.Seguranca.Models.Papel> IdentityRoles { get; set; }
    }
    public class IdentityDbInit : DropCreateDatabaseIfModelChanges <IdentityDbContextAplicacao>
    {

    }
}