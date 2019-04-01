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
    public class FornecedorAppService : IFornecedorAppService
    {
        private readonly IFornecedorService _fornecedorService;
        public FornecedorAppService(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        public FornecedorViewModel Adicionar(FornecedorViewModel obj)
        {
            return Mapper.Map<FornecedorViewModel>(_fornecedorService.Adicionar(Mapper.Map<Fornecedor>(obj)));
        }

        public FornecedorViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<FornecedorViewModel>(_fornecedorService.ObterPorId(id));
        }

        public FornecedorViewModel ObterPorUserId(Guid UserId)
        {
            return Mapper.Map<FornecedorViewModel>(_fornecedorService.ObterPorUserId(UserId));
        }

        public IEnumerable<FornecedorViewModel> ObterTodos()
        {
            return Mapper.Map<ICollection<FornecedorViewModel>>(_fornecedorService.ObterTodos());
        }

        public void Atualizar(FornecedorViewModel obj)
        {
            _fornecedorService.Atualizar(Mapper.Map<Fornecedor>(obj));
        }

        public void Remover(Guid id)
        {
            _fornecedorService.Remover(id);
        }

        public void Dispose()
        {
            _fornecedorService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
