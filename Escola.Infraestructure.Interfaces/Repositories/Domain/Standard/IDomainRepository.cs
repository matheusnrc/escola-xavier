using Escola.Infraestructure.Interfaces.Repositories.Standard;

namespace Escola.Infraestructure.Interfaces.Repositories.Domain.Standard
{
    public interface IDomainRepository<TEntity> : IRepositoryAsync<TEntity> where TEntity : class { }
}
