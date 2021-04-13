using Escola.Application.Interfaces.Services.Standard;
using Escola.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Application.Interfaces.Services
{
    public interface ICursoService : IServiceBase<Curso>
    {
        Task<List<Curso>> ObterTodos();
        Task<Curso> ObterPorId(int id);
        Task<string> Cadastrar(Curso curso);
        Task<string> Editar(Curso curso);
        Task<string> Excluir(int id);
    }
}
