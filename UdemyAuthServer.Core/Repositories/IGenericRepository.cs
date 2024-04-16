using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AuthServer.Core.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>>GetAllAsync();

        IQueryable<TEntity> Where(Expression<Func<TEntity,bool>> predicate);

        // product.To
        Task AddAsnyc(TEntity entity);
        // products.remove(product) savechange gelene kadar silinmiyor . statetinde tutar.
        void Remove(TEntity entity);

        public void Delete(int id);




        TEntity Update(TEntity entity);

        // context.Entry(Entity).State==EntityState.Modified

    }
}
