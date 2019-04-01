using SP.Domain.Entities;
using SP.Domain.Interfaces.Repository;
using SP.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(SPContext context)
            : base (context)
        {

        }

        public ICollection<Cliente> ObterPorFornecedorId(Guid fornecedorId)
        {
            return Buscar(c => c.FornecedorId == fornecedorId).ToList();
        }
    }
}
