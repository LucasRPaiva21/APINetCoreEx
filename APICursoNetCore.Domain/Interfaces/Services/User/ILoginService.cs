using APICursoNetCore.Domain.Entities;
using System.Threading.Tasks;

namespace APICursoNetCore.Domain.Interfaces.Services.User
{
    public interface ILoginService
    {
        Task<object> FindByLogin(UserEntity user);
    }
}
