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
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(SPContext context)
            : base (context)
        {

        }

        public Fornecedor ObterPorUserId(Guid userId)
        {
            return Buscar(f => f.UserId == userId).FirstOrDefault();
        }
    }
}
