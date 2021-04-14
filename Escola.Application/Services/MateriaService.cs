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
    public class MateriaService : ServiceBase<Materia>, IMateriaService
    {
        public MateriaService(IMateriaRepository repository) : base(repository) { }

        public async Task<string> Cadastrar(Materia materia)
        {
            var mensagemErro = ValidarDados(materia);
            if (!string.IsNullOrEmpty(mensagemErro))
                throw new ValidacaoException(mensagemErro);

            await repository.AddAsync(materia);
            return "Cadastro efetuado com sucesso.";
        }

        public async Task<string> Editar(Materia materia)
        {
            var aEditar = await base.GetByIdAsync(materia.Id);

            aEditar.NomeMateria = materia.NomeMateria;
            aEditar.Curso = materia.Curso;

            await base.UpdateAsync(aEditar);

            return "Edição efetuada com sucesso.";
        }

        public async Task<string> Excluir(int id)
        {
            var materia = await GetByIdAsync(id);

            if (materia == null)
                throw new ValidacaoException("Nenhum registro de materia encontrado.");

            await base.RemoveAsync(materia);

            return "Materia removida com sucesso.";
        }

        public async Task<Materia> ObterPorId(int id)
        {
            var materia = await GetByIdAsync(id);

            if (materia == null)
                throw new ValidacaoException("Nenhum registro de materia encontrado.");

            return materia;
        }

        public async Task<List<Materia>> ObterTodos()
        {
            var materia = await base.GetAllAsync();

            if (!materia.Any())
                throw new ValidacaoException("Nenhum registro encontrado.");

            return materia.ToList();
        }

        internal string ValidarDados(Materia materia)
        {
            if (materia == null)
                return "Os dados de materia é obrigatório.";

            var mensagemErro = "";

            if (string.IsNullOrEmpty(materia.NomeMateria))
                mensagemErro += $"O campo '{nameof(materia.NomeMateria)}' é obrigatório.\n";

            return mensagemErro;
        }
    }
}
