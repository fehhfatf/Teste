using SP.Application.Interfaces;
using SP.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.SP.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicoAppService _servicoAppService;
        private readonly IFornecedorAppService _fornecedorAppService;

        public HomeController(IServicoAppService servicoAppService
                                , IFornecedorAppService fornecedorAppService)
        {
            _servicoAppService = servicoAppService;
            _fornecedorAppService = fornecedorAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FornecedorSemPrestarServicoNoMes()
        {
            List<FornecedorPorMesViewModel> FornecedoresReturn = new List<FornecedorPorMesViewModel>();
            var servicos = _servicoAppService.ObterPorAno(DateTime.Now.Year.ToString());
            var fornecedores = _fornecedorAppService.ObterTodos();
            for (int i = 1; i <= DateTime.Now.Month; i++)
            {
                foreach (var item in fornecedores.OrderBy(f => f.Nome))
                {                    
                    if (servicos.Where(s => s.FornecedorId == item.FornecedorId && s.Data.Month == i).Count() == 0)
                    {
                        FornecedoresReturn.Add(new FornecedorPorMesViewModel()
                        {
                            Mes = MesLiteral(i),
                            NomeDoFornecedor = item.Nome
                        });
                    }
                }
            }
            return View(FornecedoresReturn);
        }

        public ActionResult MediaDoValorCobradoPorFornecedor()
        {
            var servicos = _servicoAppService.ObterPorAno(DateTime.Now.Year.ToString());

            var MediaReturn = from s in servicos
                              group s by new {s.FornecedorId, s.Fornecedor.Nome, s.Tipo } into sg
                              select new MediaDeValorCobradoPeloFornecedorViewModel
                              {
                                  NomeDoFornecedor = sg.Key.Nome,
                                  TipoDeServico = sg.Key.Tipo,
                                  ValorMedio = sg.Average(c => c.Valor)
                              };

            return View(MediaReturn.OrderByDescending(s => s.ValorMedio));
        }

        public ActionResult Os3ClientesQueMaisGastaramPorMes()
        {
            List<ClientePorMesViewModel> clientesReturn = new List<ClientePorMesViewModel>();            
            var servicos = from s in _servicoAppService.ObterPorAno(DateTime.Now.Year.ToString())
                       group s by new { s.Data.Month, s.Cliente.ClienteId, s.Cliente.Nome } into sg
                       select new ClientePorMesViewModel
                       {
                           Mes = MesLiteral(sg.Key.Month),
                           NomeDoCliente = sg.Key.Nome,
                           Valor = sg.Sum(c => c.Valor)
                       };      
            for (int i = 1; i <= DateTime.Now.Month; i++)
            {
                if (servicos.Where(s => s.Mes == MesLiteral(i)).Count() > 3)
                {
                    foreach (var item in servicos.Where(s => s.Mes == MesLiteral(i)).OrderByDescending(c => c.Valor).Take(3))
                    {
                        clientesReturn.Add(item);
                    }
                }
                else if (servicos.Where(s => s.Mes == MesLiteral(i)).Count() > 0)
                {
                    foreach (var item in servicos.Where(s => s.Mes == MesLiteral(i)).OrderByDescending(c => c.Valor))
                    {
                        clientesReturn.Add(item);
                    }
                }
            }
            return View(clientesReturn);
        }

        private string MesLiteral(int mes)
        {
            switch (mes)
            {
                case 1:
                    return "Janeiro";
                case 2:
                    return "Fevereiro";
                case 3:
                    return "Março";
                case 4:
                    return "Abril";
                case 5:
                    return "Maio";
                case 6:
                    return "Junho";
                case 7:
                    return "Julho";
                case 8:
                    return "Agosto";
                case 9:
                    return "Setembro";
                case 10:
                    return "Outubro";
                case 11:
                    return "Novembro";
                case 12:
                    return "Dezembro";
                default:
                    return "Erro: Existe mês atendimento invalido!";
            }
        }
    }
}