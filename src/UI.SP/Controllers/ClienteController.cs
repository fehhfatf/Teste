using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SP.Application.ViewModels;
using UI.SP.Models;
using SP.Application.Interfaces;
using SP.Infra.CrossCutting.MvcFilters;
using Microsoft.AspNet.Identity;

namespace UI.SP.Controllers
{
    [Authorize]
    [ClaimsAuthorizeAttribute("Security", "Users")]
    public class ClienteController : Controller
    {
        private readonly IClienteAppService _clienteAppService;
        private readonly IFornecedorAppService _fornecedorAppService;

        public ClienteController(IClienteAppService clienteAppService
                                    , IFornecedorAppService fornecedorAppService)
        {
            _clienteAppService = clienteAppService;
            _fornecedorAppService = fornecedorAppService;
        }

        // GET: Cliente
        public ActionResult Index()
        {
            Guid userId = new Guid(User.Identity.GetUserId());
            Guid FornecedorId = _fornecedorAppService.ObterPorUserId(userId).FornecedorId;
            return View(_clienteAppService.ObterPorFornecedorId(FornecedorId));
        }

        // GET: Cliente/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteViewModel clienteViewModel = _clienteAppService.ObterPorId(id.Value);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClienteId,Nome,Bairro,Cidade,Estado")] ClienteViewModel clienteViewModel)
        {
            clienteViewModel.FornecedorId = _fornecedorAppService.ObterPorUserId(new Guid(User.Identity.GetUserId())).FornecedorId;
            if (ModelState.IsValid)
            {
                clienteViewModel.ClienteId = Guid.NewGuid();
                _clienteAppService.Adicionar(clienteViewModel);
                return RedirectToAction("Index");
            }

            return View(clienteViewModel);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteViewModel clienteViewModel = _clienteAppService.ObterPorId(id.Value);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Atualizar(clienteViewModel);
                return RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteViewModel clienteViewModel = _clienteAppService.ObterPorId(id.Value);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {            
            _clienteAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _clienteAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
