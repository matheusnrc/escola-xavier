namespace Escola.Domain.Entities
{
    public class Curso : IIdentityEntity
    {
        public int Id { get; set; }
        public string NomeCurso { get; set; }
    }
}
