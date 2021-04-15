using System.ComponentModel.DataAnnotations.Schema;

namespace Escola.Domain.Entities
{
    public class Matricula : IIdentityEntity
    {
        public int Id { get; set; }
        public decimal? Nota { get; set; }

        [ForeignKey("Aluno")]
        public int AlunoId { get; set; }
        public virtual Aluno Aluno { get; set; }

        [ForeignKey("Materia")]
        public int MateriaId { get; set; }
        public virtual Materia Materia { get; set; }
    }
}
