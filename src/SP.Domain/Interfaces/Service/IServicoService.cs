using SP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Domain.Interfaces.Service
{
    public interface IServicoService : IService<Servico>
    {
        ICollection<Servico> ObterPorFornecedorId(Guid fornecedorId);
        ICollection<Servico> ObterPorAno(string ano);
    }
}
