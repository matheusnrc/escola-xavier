using Escola.Infraestructure.DBConfiguration;
using Escola.Infraestructure.Interfaces.Repositories.Domain;
using Escola.Infraestructure.Interfaces.Repositories.Standard;
using Escola.Infraestructure.Repositories;
using Escola.Infraestructure.Repositories.Standard;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Escola.Infraestructure.IoC.ORMs
{
    public class EntityFrameworkIoC : OrmTypes
    {
        internal override IServiceCollection AddOrm(IServiceCollection services, IConfiguration configuration = null)
        {
            IConfiguration dbConnectionSettings = ResolveConfiguration.GetConnectionSettings(configuration);
            string conn = dbConnectionSettings.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(conn));

            services.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));

            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<IMateriaRepository, MateriaRepository>();
            services.AddScoped<IMatriculaRepository, MatriculaRepository>();

            return services;
        }
    }
}
