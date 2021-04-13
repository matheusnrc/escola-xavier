using Escola.Application.Interfaces.Services.Standard;
using Escola.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Application.Interfaces.Services
{
    public interface IAlunoService : IServiceBase<Aluno>
    {
        Task<List<Aluno>> ObterTodos();
        Task<Aluno> ObterPorId(int id);
        Task<string> Cadastrar(Aluno aluno);
        Task<string> Editar(Aluno aluno);
        Task<string> Excluir(int id);
    }
}
