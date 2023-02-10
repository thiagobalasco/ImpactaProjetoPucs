using PucsMVC.Models.EF;
using System.Linq.Expressions;

namespace PucsMVC.Interfaces.Services
{
    public interface IServiceBase<TEntity> : IDisposable where TEntity : Entity
    {
        void Add(TEntity obj);
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        bool Any(Expression<Func<TEntity, bool>> predicate);
    }
}
