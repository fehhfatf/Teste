using SP.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        ClienteViewModel Adicionar(ClienteViewModel obj);
        ClienteViewModel ObterPorId(Guid id);
        ICollection<ClienteViewModel> ObterPorFornecedorId(Guid fornecedorId);
        IEnumerable<ClienteViewModel> ObterTodos();
        void Atualizar(ClienteViewModel obj);
        void Remover(Guid id);    
    }
}
