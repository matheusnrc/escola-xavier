using Escola.Infraestructure.DBConfiguration;
using Escola.Infraestructure.Interfaces.Repositories.Domain;
using Escola.Infraestructure.Repositories.Standard;

namespace Escola.Infraestructure.Repositories
{
    public class MateriaRepository : DomainRepository<Domain.Entities.Materia>, IMateriaRepository
    {
        public MateriaRepository(ApplicationContext dbContext) : base(dbContext) { }
    }
}
