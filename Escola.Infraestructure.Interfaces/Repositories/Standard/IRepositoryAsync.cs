using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Infraestructure.Interfaces.Repositories.Standard
{
    public interface IRepositoryAsync<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity obj);

        Task<TEntity> GetByIdAsync(object id);
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<int> UpdateAsync(TEntity obj);

        Task<bool> RemoveAsync(object id);
        Task<int> RemoveAsync(TEntity obj);
    }
}
