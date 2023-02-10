using PucsMVC.Interfaces.Repositories;
using PucsMVC.Interfaces.Services;
using PucsMVC.Models.EF;
using System.Linq.Expressions;

namespace PucsMVC.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : Entity
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
            _repository.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
            _repository.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            _repository.Remove(obj);
            _repository.SaveChanges();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }


        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Any(predicate);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Get(predicate);
        }
    }
}
