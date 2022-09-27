using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GORDON_STORE_BETA.Infraestrutura
{
    public static class IdentityHelpersCliente
    {
        public static MvcHtmlString GetUserName(this HtmlHelper html, string id)
        {
            GerenciadorCliente mgr = HttpContext.Current.GetOwinContext().
            GetUserManager<GerenciadorCliente>();
            return new MvcHtmlString(mgr.FindByIdAsync(id).Result.Email);
        }
        public static MvcHtmlString GetAuthenticatedUser(this HtmlHelper html)
        {
            return new MvcHtmlString(HttpContext.Current.User.Identity.Name);
        }
    }

}