namespace Escola.Domain.Entities
{
    public class Aluno : IIdentityEntity
    {
        public int Id { get; set; }
        public string NomeAluno { get; set; }
    }
}
