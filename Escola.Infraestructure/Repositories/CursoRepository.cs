using Escola.Infraestructure.DBConfiguration;
using Escola.Infraestructure.Interfaces.Repositories.Domain;
using Escola.Infraestructure.Repositories.Standard;

namespace Escola.Infraestructure.Repositories
{
    public class CursoRepository : DomainRepository<Domain.Entities.Curso>, ICursoRepository
    {
        public CursoRepository(ApplicationContext dbContext) : base(dbContext) { }
    }
}
