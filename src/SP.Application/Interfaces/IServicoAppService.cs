using SP.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Application.Interfaces
{
    public interface IServicoAppService : IDisposable
    {
        ServicoViewModel Adicionar(ServicoViewModel obj);
        ServicoViewModel ObterPorId(Guid id);
        ICollection<ServicoViewModel> ObterPorFornecedorId(Guid fornecedorId);
        ICollection<ServicoViewModel> ObterPorAno(string ano);
        IEnumerable<ServicoViewModel> ObterTodos();
        void Atualizar(ServicoViewModel obj);
        void Remover(Guid id);   
    }
}