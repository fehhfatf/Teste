using SP.Domain.Entities;
using SP.Domain.Interfaces.Repository;
using SP.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Domain.Services
{
    public class ClienteService : Service<Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
            : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public ICollection<Cliente> ObterPorFornecedorId(Guid fornecedorId)
        {
            return _clienteRepository.ObterPorFornecedorId(fornecedorId);
        }
    }
}
