using System.Collections.Generic;

namespace Escola.Domain.Entities
{
    public class Curso : IIdentityEntity
    {
        public int Id { get; set; }
        public string NomeCurso { get; set; }

        public ICollection<Materia> Materias { get; set; }
    }
}
