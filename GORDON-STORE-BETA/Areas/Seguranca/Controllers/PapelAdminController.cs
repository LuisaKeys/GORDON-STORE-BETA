using GORDON_STORE_BETA.Areas.Seguranca.Models;
using GORDON_STORE_BETA.Infraestrutura;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GORDON_STORE_BETA.Areas.Seguranca.Controllers
{
    public class PapelAdminController : Controller
    {
        // GET: Seguranca/PapelAdmin
        private GerenciadorPapel RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager
                <GerenciadorPapel>();

            }
        }
        private void AddErrorsFromResult(IdentityResult result)

        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        private GerenciadorUsuario UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().
                GetUserManager<GerenciadorUsuario>();
            }
        }
        //-------------- ACTIONS ABAIXO --------------
        // GET: Seguranca/PapelAdmin
        [Authorize/*(Roles = "Administradores")*/]
        public ActionResult Index()
        {
            return View(RoleManager.Roles);
        }
        //FET: Create
        public ActionResult Create()
        {
            return View();
        }
        //POST: Create
        [HttpPost]
        public ActionResult Create([Required] string nome)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = RoleManager.Create(new Papel(nome));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(nome);
        }
        //GET: Edit
        public ActionResult Edit(string id)
        {
            Papel papel = RoleManager.FindById(id);
            string[] memberIDs = papel.Users.Select(x => x.UserId).ToArray();
            // Carrega usuários associados e usuários não associados
            IEnumerable<UsuarioAdm> membros = UserManager.Users.Where
            (x => memberIDs.Any(y => y == x.Id));
            IEnumerable<UsuarioAdm> naoMembros = UserManager.Users.Except(membros);
            // Chama a visão
            return View(new PapelEditModel
            {
                Papel = papel,
                Membros = membros,
                NaoMembros = naoMembros
            });
        }
        //POST: Edit
        [HttpPost]
        public ActionResult Edit(PapelModificationModel model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string userId in model.IdsParaAdicionar ?? new
                string[] { })
                {
                    result = UserManager.AddToRole(userId, model.NomePapel);
                    if (!result.Succeeded)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                }
            }
            foreach (string userId in model.IdsParaRemover ?? new string[] { })
            {
                result = UserManager.RemoveFromRole(userId, model.NomePapel);
                if (!result.Succeeded)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                return RedirectToAction("Index");
            }
            //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return RedirectToAction("Index");
        }
       


    }

}