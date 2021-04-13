using Escola.Application.Interfaces.Services;
using Escola.Application.Interfaces.Services.Standard;
using Escola.Application.Services;
using Escola.Application.Services.Standard;
using Microsoft.Extensions.DependencyInjection;


namespace Escola.Application.IoC
{
    public static class ServicesIoC
    {
        public static void ApplicationServicesIoC(this IServiceCollection services)
        {
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));

            services.AddScoped<IAlunoService, AlunoService>();
        }
    }
}
