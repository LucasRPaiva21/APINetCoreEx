using ApiCursoNetCore.Service.Service;
using APICursoNetCore.Domain.Interfaces.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace APICursoNetCore.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
        }
    }
}
