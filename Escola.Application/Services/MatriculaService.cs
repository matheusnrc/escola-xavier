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
    public class MatriculaService : ServiceBase<Matricula>, IMatriculaService
    {
        public MatriculaService(IMatriculaRepository repository) : base(repository) { }

        public async Task<string> Cadastrar(Matricula matricula)
        {
            var mensagemErro = ValidarDados(matricula);
            if (!string.IsNullOrEmpty(mensagemErro))
                throw new ValidacaoException(mensagemErro);

            await repository.AddAsync(matricula);
            return "Matrícula efetuada com sucesso.";
        }

        public async Task<string> Editar(Matricula matricula)
        {
            var aEditar = await base.GetByIdAsync(matricula.Id);

            aEditar.AlunoId = matricula.AlunoId;
            aEditar. MateriaId = matricula.MateriaId;
            aEditar.Nota = matricula.Nota;

            await base.UpdateAsync(aEditar);

            return "Edição efetuada com sucesso.";
        }

        public async Task<string> Excluir(int id)
        {
            var matricula = await GetByIdAsync(id);

            if (matricula == null)
                throw new ValidacaoException("Nenhum registro de matricula encontrado.");

            await base.RemoveAsync(matricula);

            return "Matricula removida com sucesso.";
        }

        public async Task<Matricula> ObterPorId(int id)
        {
            var matricula = await GetByIdAsync(id);

            if (matricula == null)
                throw new ValidacaoException("Nenhum registro de matricula encontrado.");

            return matricula;
        }

        public async Task<List<Matricula>> ObterTodos()
        {
            var matricula = await base.GetAllAsync();

            if (!matricula.Any())
                throw new ValidacaoException("Nenhum registro encontrado.");

            return matricula.ToList();
        }

        internal string ValidarDados(Matricula matricula)
        {
            if (matricula == null)
                return "Os dados do matricula é obrigatório.";

            return "";
        }
    }
}
