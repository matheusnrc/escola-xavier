using Escola.Application.Interfaces.Services;
using Escola.Application.Services.Standard;
using Escola.Domain.Entities;
using Escola.Infraestructure.Interfaces.Repositories.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Application.Services
{
    public class AlunoService : ServiceBase<Aluno>, IAlunoService
    {
        public AlunoService(IAlunoRepository repository) : base(repository) { }

        public Task<string> Cadastrar(Aluno aluno)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> Editar(Aluno aluno)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> Excluir(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Aluno> ObterPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Aluno>> ObterTodos()
        {
            throw new System.NotImplementedException();
        }
    }
}
