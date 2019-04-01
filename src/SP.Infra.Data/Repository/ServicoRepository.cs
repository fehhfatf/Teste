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
    public class ServicoRepository : Repository<Servico>, IServicoRepository
    {
        public ServicoRepository(SPContext context)
            : base(context)
        {

        }

        public ICollection<Servico> ObterPorFornecedorId(Guid fornecedorId)
        {
            return Buscar(s => s.FornecedorId == fornecedorId).ToList();
        }
    }
}
