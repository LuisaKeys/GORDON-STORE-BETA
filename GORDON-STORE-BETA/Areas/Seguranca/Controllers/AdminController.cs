using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using GORDON_STORE_BETA.Infraestrutura;
using Microsoft.AspNet.Identity;
using GORDON_STORE_BETA.Areas.Seguranca.Models;
using Modelo.Sistema;
using System.Net;

namespace GORDON_STORE_BETA.Areas.Seguranca.Controllers
{
    public class AdminController : Controller
    {
        // Definição da Propriedade GerenciadorUsuario
        private GerenciadorUsuario GerenciadorUsuario
        {
            get
            {
                return HttpContext.GetOwinContext().
                GetUserManager<GerenciadorUsuario>();

            }
        }
        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        //---------------- ACTIONS ABAIXO ----------------
        // GET: Seguranca/Admin
        [Authorize/*(Roles = "Administradores")*/]
        public ActionResult Index()
        {
            return View(GerenciadorUsuario.Users);
        }
        //GET: Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                UsuarioAdm user = new UsuarioAdm
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Nome = model.Nome,
                    Sobrenome = model.Sobrenome,
                    Cpf = model.Cpf,
                    Estado = model.Estado,
                    Cidade = model.Cidade,
                    Rua = model.Rua,
                    Numero = model.Numero,
                    Complemento = model.Complemento,
                    DataNascimento = model.DataNascimento

                };
                IdentityResult result = GerenciadorUsuario.Create(user, model.Senha);
                if (result.Succeeded)
                { 
                    return RedirectToAction("Index"); 
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(model);
        }
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioAdm usuario = GerenciadorUsuario.FindById(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            
            var uvm = new UsuarioViewModel();
            uvm.Id = usuario.Id;
            uvm.UserName = usuario.UserName;
            uvm.Email = usuario.Email;
            return View(uvm);
        }
        [HttpPost]
        public ActionResult Edit(UsuarioViewModel uvm)
        {
            if (ModelState.IsValid)
            {
                UsuarioAdm usuario = GerenciadorUsuario.FindById(uvm.Id);
                usuario.UserName = uvm.UserName;
                usuario.Email = uvm.Email;
                usuario.PasswordHash = GerenciadorUsuario.PasswordHasher.
                HashPassword(uvm.Senha);
                IdentityResult result = GerenciadorUsuario.Update(usuario);
                if (result.Succeeded)
                { return RedirectToAction("Index"); }
                else
                { AddErrorsFromResult(result); }
            }
            return View(uvm);
        }
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            UsuarioAdm usuario = GerenciadorUsuario.FindById(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }
        [HttpPost]
        public ActionResult Delete(UsuarioAdm usuario)
        {
            UsuarioAdm user = GerenciadorUsuario.FindById(usuario.Id);
            if (user != null)
            {
                IdentityResult result = GerenciadorUsuario.Delete(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return HttpNotFound();
            }
        }
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            UsuarioAdm usuario = GerenciadorUsuario.FindById(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }
    }
}

