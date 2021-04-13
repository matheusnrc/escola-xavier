namespace Escola.Domain.Entities
{
    public class Matricula : IIdentityEntity
    {
        public int Id { get; set; }
        public decimal Nota { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual Materia Materia { get; set; }
    }
}
