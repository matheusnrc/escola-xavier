using Escola.Application.Interfaces.Services;
using Escola.Application.Services.Standard;
using Escola.Domain;
using Escola.Domain.DTOs;
using Escola.Domain.Entities;
using Escola.Infraestructure.Interfaces.Repositories.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.Application.Services
{
    public class MatriculaService : ServiceBase<Matricula>, IMatriculaService
    {
        private readonly IAlunoService _alunoService;
        private readonly IMateriaService _materiaService;

        public MatriculaService(IMatriculaRepository repository, IAlunoService alunoService, IMateriaService materiaService) : base(repository)
        {
            _alunoService = alunoService;
            _materiaService = materiaService;
        }

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
            aEditar.MateriaId = matricula.MateriaId;
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

        public async Task<List<MatriculaDto>> ObterStatusMatricula()
        {
            var matriculas = await base.GetAllAsync();

            //Montar DTO
            var statusDosAlunos = new List<MatriculaDto>();
            foreach (var item in matriculas.ToList())
            {
                var statusAluno = new MatriculaDto();

                statusAluno.Id = item.Id;
                statusAluno.MateriaId = item.MateriaId;
                statusAluno.AlunoId = item.AlunoId;

                statusAluno.NomeAluno = (await _alunoService.GetByIdAsync(item.AlunoId)).NomeAluno;
                statusAluno.NomeMateria = (await _materiaService.GetByIdAsync(item.MateriaId)).NomeMateria;

                statusAluno.Nota = item.Nota;
                statusAluno.Status = item.Nota == null ? "Cursando" : item.Nota >= 7 ? "Aprovado" : "Reprovado";

                statusDosAlunos.Add(statusAluno);
            }

            return statusDosAlunos;
        }

        public async Task<List<Matricula>> ObterTodos()
        {
            var matricula = await base.GetAllAsync();

            var teste = await _alunoService.GetByIdAsync(1);

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
