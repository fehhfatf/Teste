using AutoMapper;
using SP.Application.Interfaces;
using SP.Application.ViewModels;
using SP.Domain.Entities;
using SP.Domain.Interfaces.Service;
using SP.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Application.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteService _clienteService;
        public ClienteAppService(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public ClienteViewModel Adicionar(ClienteViewModel obj)
        {
            return Mapper.Map<ClienteViewModel>(_clienteService.Adicionar(Mapper.Map<Cliente>(obj)));
        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ClienteViewModel>(_clienteService.ObterPorId(id));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<ICollection<ClienteViewModel>>(_clienteService.ObterTodos());
        }

        public void Atualizar(ClienteViewModel obj)
        {
            _clienteService.Atualizar(Mapper.Map<Cliente>(obj));
        }

        public void Remover(Guid id)
        {
            _clienteService.Remover(id);
        }

        public void Dispose()
        {
            _clienteService.Dispose();
            GC.SuppressFinalize(this);
        }

        public ICollection<ClienteViewModel> ObterPorFornecedorId(Guid fornecedorId)
        {
            return Mapper.Map<ICollection<ClienteViewModel>>(_clienteService.ObterPorFornecedorId(fornecedorId));
        }
    }
}
