using ProdutosApp.Domain.Interfaces.Repositories;
using ProdutosApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        private readonly DataContext _dataContext;

        protected BaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public virtual void Add(TEntity entity)
        {
            _dataContext.Add(entity);
            _dataContext.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _dataContext.Update(entity);
            _dataContext.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            _dataContext.Remove(entity);
            _dataContext.SaveChanges();
        }

        public virtual List<TEntity> GetAll()
        {
            return _dataContext.Set<TEntity>().ToList();
        }

        public virtual TEntity? GetById(int id)
        {
            return _dataContext.Set<TEntity>().Find(id);
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
