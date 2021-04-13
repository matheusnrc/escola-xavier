using Microsoft.EntityFrameworkCore;
using Escola.Infraestructure.Interfaces.Repositories.Standard;
using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Infraestructure.Repositories.Standard
{
    public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : class, IIdentityEntity
    {
        protected readonly DbContext dbContext;
        protected readonly DbSet<TEntity> dbSet;

        protected RepositoryAsync(DbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = this.dbContext.Set<TEntity>();
        }

        public void Dispose()
        {
            dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual async Task<TEntity> AddAsync(TEntity obj)
        {
            var r = await dbSet.AddAsync(obj);
            await CommitAsync();
            return r.Entity;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Task.FromResult(dbSet);
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<bool> RemoveAsync(object id)
        {
            TEntity entity = await GetByIdAsync(id);

            if (entity == null) return false;

            return await RemoveAsync(entity) > 0 ? true : false;
        }

        public virtual async Task<int> RemoveAsync(TEntity obj)
        {
            dbSet.Remove(obj);
            return await CommitAsync();
        }

        public virtual async Task<int> UpdateAsync(TEntity obj)
        {
            var avoidingAttachedEntity = await GetByIdAsync(obj.Id);
            dbContext.Entry(avoidingAttachedEntity).State = EntityState.Detached;

            var entry = dbContext.Entry(obj);
            if (entry.State == EntityState.Detached) dbContext.Attach(obj);

            dbContext.Entry(obj).State = EntityState.Modified;
            return await CommitAsync();
        }

        private async Task<int> CommitAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
