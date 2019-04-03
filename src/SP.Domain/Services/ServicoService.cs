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
    public class ServicoService : Service<Servico>, IServicoService
    {
        private readonly IServicoRepository _servicoRepository;
        public ServicoService(IServicoRepository servicoRepository)
            : base (servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        public ICollection<Servico> ObterPorFornecedorId(Guid fornecedorId)
        {
            return _servicoRepository.ObterPorFornecedorId(fornecedorId);
        }


        public ICollection<Servico> ObterPorAno(string ano)
        {
            return _servicoRepository.ObterPorAno(ano);
        }
    }
}
