using Escola.Application.Interfaces.Services.Standard;
using Escola.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Application.Interfaces.Services
{
    public interface IMateriaService : IServiceBase<Materia>
    {
        Task<List<Materia>> ObterTodos();
        Task<Materia> ObterPorId(int id);
        Task<string> Cadastrar(Materia materia);
        Task<string> Editar(Materia materia);
        Task<string> Excluir(int id);
    }
}

