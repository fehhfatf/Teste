using SP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Domain.Interfaces.Service
{
    public interface IFornecedorService : IService<Fornecedor>
    {
        Fornecedor ObterPorUserId(Guid userId);
    }
}
