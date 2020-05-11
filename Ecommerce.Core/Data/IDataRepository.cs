using Ecommerce.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Data
{
    public interface IDataRepository<T>
        where T: BaseEntity
    {
        Task<Guid> AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);

        Task<T> GetAsync(Guid entityId, bool allowNull = false);

        Task<T> GetAsync(Expression<Func<T, bool>> expression, bool allowNull = false);

        Task<IList<T>> FindAllAsync();

        Task UpdateAsync(T entity);

        //Task<IList<T>> 
    }
}
