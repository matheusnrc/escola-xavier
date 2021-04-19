namespace Escola.Domain.DTOs
{
    public class MatriculaDto
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public string NomeAluno { get; set; }
        public int MateriaId { get; set; }

        public string NomeMateria { get; set; }
        public decimal? Nota { get; set; }
        public string Status { get; set; }
    }
}
