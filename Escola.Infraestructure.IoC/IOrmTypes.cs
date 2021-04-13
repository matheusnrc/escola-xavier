using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Escola.Infraestructure.IoC
{
    public interface IOrmTypes
    {
        IServiceCollection ResolveOrm(IServiceCollection services, IConfiguration configuration = null);
    }
}
