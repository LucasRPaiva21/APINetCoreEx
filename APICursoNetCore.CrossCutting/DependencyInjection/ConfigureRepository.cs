using ApiCursoNetCore.Data.Context;
using ApiCursoNetCore.Data.Implementations;
using ApiCursoNetCore.Data.Repository;
using APICursoNetCore.Domain.Interfaces;
using APICursoNetCore.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace APICursoNetCore.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementations>();

            serviceCollection.AddDbContext<MyContext>(
                options => options.UseMySql("Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=12345678")
            );
        }
    }
}
