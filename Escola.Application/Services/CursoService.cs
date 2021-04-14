using Escola.Application.Interfaces.Services;
using Escola.Application.Services.Standard;
using Escola.Domain;
using Escola.Domain.Entities;
using Escola.Infraestructure.Interfaces.Repositories.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.Application.Services
{
    public class CursoService : ServiceBase<Curso>, ICursoService
    {
        public CursoService(ICursoRepository repository) : base(repository) { }

        public async Task<string> Cadastrar(Curso curso)
        {
            var mensagemErro = ValidarDados(curso);
            if (!string.IsNullOrEmpty(mensagemErro))
                throw new ValidacaoException(mensagemErro);

            await repository.AddAsync(curso);
            return "Cadastro efetuado com sucesso.";
        }

        public async Task<string> Editar(Curso curso)
        {
            var aEditar = await base.GetByIdAsync(curso.Id);

            aEditar.NomeCurso= curso.NomeCurso;

            await base.UpdateAsync(aEditar);

            return "Edição efetuada com sucesso.";
        }

        public async Task<string> Excluir(int id)
        {
            var curso = await GetByIdAsync(id);

            if (curso == null)
                throw new ValidacaoException("Nenhum registro de curso encontrado.");

            await base.RemoveAsync(curso);

            return "Curso removido com sucesso.";
        }

        public async Task<Curso> ObterPorId(int id)
        {
            var curso = await GetByIdAsync(id);

            if (curso == null)
                throw new ValidacaoException("Nenhum registro de curso encontrado.");

            return curso;
        }

        public async Task<List<Curso>> ObterTodos()
        {
            var cursos = await base.GetAllAsync();

            if (!cursos.Any())
                throw new ValidacaoException("Nenhum registro encontrado.");

            return cursos.ToList();
        }

        internal string ValidarDados(Curso curso)
        {
            if (curso == null)
                return "Os dados do curso é obrigatório.";

            var mensagemErro = "";

            if (string.IsNullOrEmpty(curso.NomeCurso))
                mensagemErro += $"O campo '{nameof(curso.NomeCurso)}' é obrigatório.\n";

            return mensagemErro;
        }
    }
}
