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
    public class FornecedorService: Service<Fornecedor>, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        public FornecedorService(IFornecedorRepository fornecedorRepository)
            : base (fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public Fornecedor ObterPorUserId(Guid userId)
        {
            return _fornecedorRepository.ObterPorUserId(userId);
        }
    }
}
