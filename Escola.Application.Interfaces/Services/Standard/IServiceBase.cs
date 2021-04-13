using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Application.Interfaces.Services.Standard
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity obj);

        Task<TEntity> GetByIdAsync(object id);
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task UpdateAsync(TEntity obj);

        Task<bool> RemoveAsync(object id);
        Task RemoveAsync(TEntity obj);
    }
}

