namespace Escola.Domain.Entities
{
    public class Materia : IIdentityEntity
    {
        public int Id { get; set; }
        public string NomeMateria { get; set; }
        public virtual Curso Curso { get; set; }
    }
}
