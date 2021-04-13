using Escola.Domain.Entities;
using Escola.Infraestructure.Interfaces.Repositories.Domain.Standard;
using Microsoft.EntityFrameworkCore;

namespace Escola.Infraestructure.Repositories.Standard
{
    public class DomainRepository<TEntity> : RepositoryAsync<TEntity>, IDomainRepository<TEntity> where TEntity : class, IIdentityEntity
    {
        protected DomainRepository(DbContext dbContext) : base(dbContext) { }
    }
}
