using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using SP.Application.Interfaces;
using SP.Application.ViewModels;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UI.SP.Models;

namespace UI.SP.Controllers
{
    [Authorize]
    [ClaimsAuthorizeAttribute("Security","Adm")]
    public class FornecedorController : Controller
    {
        private readonly IFornecedorAppService _fornecedorAppService;
        private readonly IClienteAppService _clienteAppService;
        private readonly IServicoAppService _servicosAppService;

        public FornecedorController(IFornecedorAppService fornecedorAppService
                                    , IClienteAppService clienteAppService
                                    , IServicoAppService servicosAppService)
        {
            _fornecedorAppService = fornecedorAppService;
            _clienteAppService = clienteAppService;
            _servicosAppService = servicosAppService;
        }

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        
        // GET: Fornecedor
        public ActionResult Index()
        {
            return View(_fornecedorAppService.ObterTodos());
        }

        // GET: Fornecedor/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorViewModel fornecedorViewModel = _fornecedorAppService.ObterPorId(id.Value);
            if (fornecedorViewModel == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorViewModel);
        }

        // GET: Fornecedor/Create
        public ActionResult Create()
        {
            return View();
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        // POST: Fornecedor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(FornecedorViewModel fornecedorViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = fornecedorViewModel.Email, Email = fornecedorViewModel.Email };
                user.Claims.Add(new IdentityUserClaim() { UserId=user.Id, ClaimType="Security", ClaimValue="Users"});
                var result = await UserManager.CreateAsync(user, fornecedorViewModel.Password);  
                if (result.Succeeded)
                {                                       
                    fornecedorViewModel.FornecedorId = Guid.NewGuid();
                    fornecedorViewModel.UserId = new Guid(user.Id);
                    _fornecedorAppService.Adicionar(fornecedorViewModel);                    
                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }                                         
            return View(fornecedorViewModel);
        }

        // GET: Fornecedor/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorViewModel fornecedorViewModel = _fornecedorAppService.ObterPorId(id.Value);
            if (fornecedorViewModel == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorViewModel);
        }

        // POST: Fornecedor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FornecedorViewModel fornecedorViewModel)
        {
            if (ModelState.IsValid)
            {
                _fornecedorAppService.Atualizar(fornecedorViewModel);
                return RedirectToAction("Index");
            }
            return View(fornecedorViewModel);
        }

        // GET: Fornecedor/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorViewModel fornecedorViewModel = _fornecedorAppService.ObterPorId(id.Value);
            if (fornecedorViewModel == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorViewModel);
        }

        // POST: Fornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _fornecedorAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _fornecedorAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}