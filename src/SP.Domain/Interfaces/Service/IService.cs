using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SP.Domain.Interfaces.Service
{
    public interface IService<TEntity> : IDisposable where TEntity : class
    {
        TEntity Adicionar(TEntity obj);
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
        void Atualizar(TEntity obj);
        void Remover(Guid id);
        int SaveChanges();     
    }
}
