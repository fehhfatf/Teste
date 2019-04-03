using AutoMapper;
using SP.Application.Interfaces;
using SP.Application.ViewModels;
using SP.Domain.Entities;
using SP.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Application.Services
{
    public class ServicoAppService : IServicoAppService
    {
        private readonly IServicoService _servicoService;
        public ServicoAppService(IServicoService servicoService)
        {
            _servicoService = servicoService;
        }

        public ServicoViewModel Adicionar(ServicoViewModel obj)
        {
            return Mapper.Map<ServicoViewModel>(_servicoService.Adicionar(Mapper.Map<Servico>(obj)));
        }

        public ServicoViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ServicoViewModel>(_servicoService.ObterPorId(id));
        }

        public IEnumerable<ServicoViewModel> ObterTodos()
        {
            return Mapper.Map<ICollection<ServicoViewModel>>(_servicoService.ObterTodos());
        }

        public void Atualizar(ServicoViewModel obj)
        {
            _servicoService.Atualizar(Mapper.Map<Servico>(obj));
        }

        public void Remover(Guid id)
        {
            _servicoService.Remover(id);
        }

        public void Dispose()
        {
            _servicoService.Dispose();
            GC.SuppressFinalize(this);
        }

        public ICollection<ServicoViewModel> ObterPorFornecedorId(Guid fornecedorId)
        {
            return Mapper.Map<ICollection<ServicoViewModel>>(_servicoService.ObterPorFornecedorId(fornecedorId));
        }


        public ICollection<ServicoViewModel> ObterPorAno(string ano)
        {
            return Mapper.Map<ICollection<ServicoViewModel>>(_servicoService.ObterPorAno(ano));
        }
    }
}
