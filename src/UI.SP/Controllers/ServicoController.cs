﻿using Microsoft.AspNet.Identity;
using SP.Application.Interfaces;
using SP.Application.ViewModels;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace UI.SP.Controllers
{
    [Authorize]
    [ClaimsAuthorizeAttribute("Security", "Users")]
    public class ServicoController : Controller
    {
        private readonly IClienteAppService _clienteAppService;
        private readonly IFornecedorAppService _fornecedorAppService;
        private readonly IServicoAppService _servicoAppService;


        public ServicoController(IServicoAppService servicoAppService
                                ,   IFornecedorAppService fornecedorAppService
                                ,   IClienteAppService clienteAppService)
        {
            _servicoAppService = servicoAppService;
            _fornecedorAppService = fornecedorAppService;
            _clienteAppService = clienteAppService;
        }

        // GET: ServicoViewModels
        public ActionResult Index()
        {
            Guid FornecedorId = _fornecedorAppService.ObterPorUserId(new Guid(User.Identity.GetUserId())).FornecedorId;
            var servico = _servicoAppService.ObterPorFornecedorId(FornecedorId);
            return View(servico);
        }

        public ActionResult Pesquisar(string de, string ate, string filtrarPor, string contendo, string ordenar)
        {
            Guid FornecedorId = _fornecedorAppService.ObterPorUserId(new Guid(User.Identity.GetUserId())).FornecedorId;
            var servico = _servicoAppService.ObterPorFornecedorId(FornecedorId);
            if (de != "")
                servico = servico.Where(s => s.Data >= Convert.ToDateTime(de)).ToList();

            if (ate != "")
                servico = servico.Where(s => s.Data <= Convert.ToDateTime(ate)).ToList();

            if (filtrarPor != "nada")
            {
                if (filtrarPor == "cliente")
                    servico = servico.Where(s => s.Cliente.Nome.ToUpper().Contains(contendo.ToUpper())).ToList();

                if (filtrarPor == "estado")
                    servico = servico.Where(s => s.Cliente.Estado.ToUpper().Contains(contendo.ToUpper())).ToList();

                if (filtrarPor == "cidade")
                    servico = servico.Where(s => s.Cliente.Cidade.ToUpper().Contains(contendo.ToUpper())).ToList();

                if (filtrarPor == "bairro")
                    servico = servico.Where(s => s.Cliente.Bairro.ToUpper().Contains(contendo.ToUpper())).ToList();

                if (filtrarPor == "tipoServico")
                    servico = servico.Where(s => s.Tipo.ToUpper().Contains(contendo.ToUpper())).ToList();                                
            }

            if (ordenar == "valorMinimo")
                servico = servico.OrderBy(s => s.Valor).ToList();

            if (ordenar == "valorMaximo")
                servico = servico.OrderByDescending(s => s.Valor).ToList();    

            return PartialView("_servicos", servico);
        }        


        // GET: ServicoViewModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicoViewModel servicoViewModel = _servicoAppService.ObterPorId(id.Value);
            if (servicoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(servicoViewModel);
        }

        // GET: ServicoViewModels/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(_clienteAppService.ObterPorFornecedorId(_fornecedorAppService.ObterPorUserId(new Guid(User.Identity.GetUserId())).FornecedorId), "ClienteId", "Nome");
            return View();
        }

        // POST: ServicoViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServicoId,FornecedorId,ClienteId,Descricao,Data,Valor,Tipo")] ServicoViewModel servicoViewModel)
        {
            servicoViewModel.FornecedorId = _fornecedorAppService.ObterPorUserId(new Guid(User.Identity.GetUserId())).FornecedorId;
            if (ModelState.IsValid)
            {
                servicoViewModel.ServicoId = Guid.NewGuid();
                _servicoAppService.Adicionar(servicoViewModel);
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(_clienteAppService.ObterPorFornecedorId(_fornecedorAppService.ObterPorUserId(new Guid(User.Identity.GetUserId())).FornecedorId), "ClienteId", "Nome", servicoViewModel.ClienteId);            
            return View(servicoViewModel);
        }

        // GET: ServicoViewModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicoViewModel servicoViewModel = _servicoAppService.ObterPorId(id.Value);
            if (servicoViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(_clienteAppService.ObterPorFornecedorId(_fornecedorAppService.ObterPorUserId(new Guid(User.Identity.GetUserId())).FornecedorId), "ClienteId", "Nome", servicoViewModel.ClienteId);            
            return View(servicoViewModel);
        }

        // POST: ServicoViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServicoId,FornecedorId,ClienteId,Descricao,Data,Valor,Tipo")] ServicoViewModel servicoViewModel)
        {            
            if (ModelState.IsValid)
            {
                _servicoAppService.Atualizar(servicoViewModel);
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(_clienteAppService.ObterPorFornecedorId(_fornecedorAppService.ObterPorUserId(new Guid(User.Identity.GetUserId())).FornecedorId), "ClienteId", "Nome", servicoViewModel.ClienteId);            
            return View(servicoViewModel);
        }

        // GET: ServicoViewModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicoViewModel servicoViewModel = _servicoAppService.ObterPorId(id.Value);
            if (servicoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(servicoViewModel);
        }

        // POST: ServicoViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _servicoAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _servicoAppService.Dispose();
            }
            base.Dispose(disposing);
        }        
    }
}
