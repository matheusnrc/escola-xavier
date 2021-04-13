using Escola.Infraestructure.DBConfiguration;
using Escola.Infraestructure.Interfaces.Repositories.Domain;
using Escola.Infraestructure.Repositories.Standard;

namespace Escola.Infraestructure.Repositories
{
    public class MatriculaRepository : DomainRepository<Domain.Entities.Matricula>, IMatriculaRepository
    {
        public MatriculaRepository(ApplicationContext dbContext) : base(dbContext) { }
    }
}
