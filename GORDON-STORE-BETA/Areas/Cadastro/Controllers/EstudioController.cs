using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using Modelo.Cadastro;
using Servico.Cadastro;

namespace GORDON_STORE_BETA.Areas.Cadastro.Controllers
{
    public class EstudioController : Controller
    {
        private EstudioServico estudioServico = new EstudioServico();

        //Pega os detalhes do estúdio de acordo com o id, serve para diminuir a redundância na hora de mostrar vz
        private ActionResult ObterVisaoEstudioPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Estudio estudio = estudioServico.ObterEstudioPorId((long) id);
            if (estudio == null)
            {
                return HttpNotFound();
            }
            return View(estudio);
        }
        //Salva dados do Estúdio
        private ActionResult GravarEstudio(Estudio estudio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    estudioServico.GravarEstudio(estudio);
                    return RedirectToAction("Index");
                }
                return View(estudio);
            }
            catch
            {
                return View(estudio);
            }
        }

        //---------------------- ACTIONS ABAIXO -----------------------//
        // GET: Estudio
        public ActionResult Index()
        {
            return View(estudioServico.ObterEstudiosClassificadosPorNome());
        }

        // GET: Estudio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Estudio estudio)
        {
            return GravarEstudio(estudio);
        }
        // GET: Edit
        public ActionResult Edit(long? id)
        {
            return ObterVisaoEstudioPorId(id);
        }
        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Estudio estudio)
        {
            return GravarEstudio(estudio);
        }
        // GET: Details
        public ActionResult Details(long? id)
        {
            return ObterVisaoEstudioPorId(id);
        }
        // GET: Delete
        public ActionResult Delete(long? id)
        {
            return ObterVisaoEstudioPorId(id);
        }
        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Estudio estudio = estudioServico.EliminarEstudioPorId(id);
                TempData["Message"] = "Estúdio " + estudio.Nome.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
