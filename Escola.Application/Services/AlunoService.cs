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
    public class AlunoService : ServiceBase<Aluno>, IAlunoService
    {
        public AlunoService(IAlunoRepository repository) : base(repository) { }

        public async Task<string> Cadastrar(Aluno aluno)
        {
            var mensagemErro = ValidarDados(aluno);
            if (!string.IsNullOrEmpty(mensagemErro))
                throw new ValidacaoException(mensagemErro);

            await repository.AddAsync(aluno);
            return "Cadastro efetuado com sucesso.";
        }

        public async Task<string> Editar(Aluno aluno)
        {
            var aEditar = await base.GetByIdAsync(aluno.Id);

            aEditar.NomeAluno = aluno.NomeAluno;
     
            await base.UpdateAsync(aEditar);

            return "Edição efetuada com sucesso.";
        }

        public async Task<string> Excluir(int id)
        {
            var aluno = await GetByIdAsync(id);

            if (aluno == null)
                throw new ValidacaoException("Nenhum registro de aluno encontrado.");

            await base.RemoveAsync(aluno);

            return "Produto removido com sucesso.";
        }

        public async Task<Aluno> ObterPorId(int id)
        {
            var aluno = await GetByIdAsync(id);

            if (aluno == null)
                throw new ValidacaoException("Nenhum registro de aluno encontrado.");

            return aluno;
        }

        public async Task<List<Aluno>> ObterTodos()
        {
            var alunos = await base.GetAllAsync();

            if(!alunos.Any())
                throw new ValidacaoException("Nenhum registro encontrado.");

            return alunos.ToList();
        }

        internal string ValidarDados(Aluno aluno)
        {
            if (aluno == null)
                return "Os dados do aluno é obrigatório.";

            var mensagemErro = "";

            if (string.IsNullOrEmpty(aluno.NomeAluno))
                mensagemErro += $"O campo '{nameof(aluno.NomeAluno)}' é obrigatório.\n";

            return mensagemErro;
        }
    }
}
