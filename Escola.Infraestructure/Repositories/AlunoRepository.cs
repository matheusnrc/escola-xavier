using Escola.Infraestructure.DBConfiguration;
using Escola.Infraestructure.Interfaces.Repositories.Domain;
using Escola.Infraestructure.Repositories.Standard;

namespace Escola.Infraestructure.Repositories
{
    public class AlunoRepository : DomainRepository<Domain.Entities.Aluno>, IAlunoRepository
    {
        public AlunoRepository(ApplicationContext dbContext) : base(dbContext) { }
    }
}
