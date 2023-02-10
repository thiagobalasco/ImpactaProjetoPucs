using Microsoft.EntityFrameworkCore;
using PucsMVC.Interfaces.Repositories;
using PucsMVC.Models.EF;
using System.Linq.Expressions;

namespace PucsMVC.Data.Respositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
    {
        protected readonly ApplicationDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public RepositoryBase(ApplicationDbContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.AsNoTracking();
        }

        public TEntity GetById(int id)
        {
            return DbSet.FirstOrDefault(c => c.Id == id);
        }

        public void Remove(TEntity obj)
        {
            DbSet.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            Db.Attach(obj);
            Db.Entry(obj).State = EntityState.Modified;
            Db.Update(obj);
        }

        public void SaveChanges()
        {
            Db.SaveChanges();
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }
    }
}
