using Escola.Application.Interfaces.Services.Standard;
using Escola.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Application.Interfaces.Services
{
    public interface IMatriculaService : IServiceBase<Matricula>
    {
        Task<List<Matricula>> ObterTodos();
        Task<Matricula> ObterPorId(int id);
        Task<string> Cadastrar(Matricula matricula);
        Task<string> Editar(Matricula matricula);
        Task<string> Excluir(int id);
    }
}
