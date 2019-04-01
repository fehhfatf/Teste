using SP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Domain.Interfaces.Service
{
    public interface IClienteService : IService<Cliente>
    {
        ICollection<Cliente> ObterPorFornecedorId(Guid fornecedorId);
    }
}
