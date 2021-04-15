using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escola.Domain.Entities
{
    public class Materia : IIdentityEntity
    {
        public int Id { get; set; }
        public string NomeMateria { get; set; }

        [ForeignKey("Curso")]
        public int CursoId { get; set; }
        public virtual Curso Curso { get; set; }

        public ICollection<Matricula> Matriculas{ get; set; }

    }
}
