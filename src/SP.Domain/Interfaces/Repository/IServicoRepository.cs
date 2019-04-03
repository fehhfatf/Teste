using SP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Domain.Interfaces.Repository
{
    public interface IServicoRepository : IRepository<Servico>
    {
        ICollection<Servico> ObterPorFornecedorId(Guid fornecedorId);
        ICollection<Servico> ObterPorAno(string ano);
    }
}
