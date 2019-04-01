using SP.Domain.Interfaces.Repository;
using SP.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SP.Domain.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {       
        private readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public TEntity Adicionar(TEntity obj)
        {
            return _repository.Adicionar(obj);
        }

        public TEntity ObterPorId(Guid id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public void Atualizar(TEntity obj)
        {
            _repository.Atualizar(obj);
        }

        public void Remover(Guid id)
        {
            _repository.Remover(id);
        }

        public int SaveChanges()
        {
            return _repository.SaveChanges();
        }

        public void Dispose()
        {
            _repository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
