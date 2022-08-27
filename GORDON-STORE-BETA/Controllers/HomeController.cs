using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using GORDON_STORE_BETA.Areas.Seguranca.Models;
using GORDON_STORE_BETA.Infraestrutura;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace GORDON_STORE_BETA.Areas.Seguranca.Controllers
{
    public class HomeController : Controller
    {
        // GET: Seguranca/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}