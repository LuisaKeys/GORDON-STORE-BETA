using GORDON_STORE_BETA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using GORDON_STORE_BETA.Context;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GORDON_STORE_BETA.Controllers
{
    public class ClienteController : Controller
    {
        public EFContext context = new EFContext(); 
        //private static IList<Cliente> clientes= new List<Cliente>()
        //{
        //    new Cliente() { clienteID = 1, nome = "Lindoberg"},
        //    new Cliente() { clienteID = 2, nome = "Leo"},
        //    new Cliente() { clienteID = 3, nome = "Luisa"},
        //};
        // GET: Cliente
        public ActionResult Index()
        {
            return View(context.Clientes.OrderBy(c => c.nome));
        }
        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            context.Clientes.Add(cliente);
            context.SaveChanges();
            //cliente.clienteID = clientes.Select(m => m.clienteID).Max() + 1;
            return RedirectToAction("Index");
        }

        //public ActionResult Edit(long id)
        //{
        //    return View(categorias.Where(m => m.CategoriaId == id).First());
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Categoria categoria)
        //{
        //    categorias.Remove(
        //    categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());
        //    categorias.Add(categoria);
        //    return RedirectToAction("Index");
        //}

        //public ActionResult Details(long id)
        //{
        //    return View(categorias.Where(m => m.CategoriaId == id).First());
        //}

        //public ActionResult Delete(long id)
        //{
        //    return View(categorias.Where(m => m.CategoriaId == id).First());
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(Categoria categoria)
        //{
        //    categorias.Remove(
        //    categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());
        //    return RedirectToAction("Index");
        //}
    }
}