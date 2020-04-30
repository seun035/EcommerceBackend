using Ecommerce.Core.Common;
using Ecommerce.Core.Data;
using Ecommerce.Core.Exceptions;
using Ecommerce.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repositories
{
    public abstract class DataRepository<T> : IDataRepository<T>
        where T : BaseEntity
    {
        private readonly EcommerceDbContext _dbContext;

        protected DataRepository(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> AddAsync(T entity)
        {
            ArgumentGuard.NotNull(entity, nameof(entity));

            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetAsync(Guid entityId, bool allowNull = false)
        {
            ArgumentGuard.NotEmpty(entityId, nameof(entityId));

            var entity = await _dbContext.Set<T>().FindAsync(entityId);

            if (entity == null && !allowNull)
            {
                throw new ObjectNotFoundException($"No record found that matches the given Id {entityId}");
            }

            return entity;
        }

        public async Task<IList<T>> FindAllAsync()
        {
           return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            ArgumentGuard.NotNull(entity, nameof(entity));

            _dbContext.Entry<T>(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
