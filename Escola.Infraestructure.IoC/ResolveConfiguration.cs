using Escola.Infraestructure.DBConfiguration;
using Microsoft.Extensions.Configuration;

namespace Escola.Infraestructure.IoC
{
    internal class ResolveConfiguration
    {
        public static IConfiguration GetConnectionSettings(IConfiguration configuration)
        {
            return configuration ?? DatabaseConnection.ConnectionConfiguration;
        }
    }
}
