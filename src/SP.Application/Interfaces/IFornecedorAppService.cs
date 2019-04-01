using SP.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Application.Interfaces
{
    public interface IFornecedorAppService : IDisposable
    {
        FornecedorViewModel Adicionar(FornecedorViewModel obj);
        FornecedorViewModel ObterPorId(Guid id);
        FornecedorViewModel ObterPorUserId(Guid UserId);
        IEnumerable<FornecedorViewModel> ObterTodos();
        void Atualizar(FornecedorViewModel obj);
        void Remover(Guid id);   
    }
}
