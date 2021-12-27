using APICursoNetCore.Domain.DTOs;
using System.Threading.Tasks;

namespace APICursoNetCore.Domain.Interfaces.Services.User
{
    public interface ILoginService
    {
        Task<object> FindByLogin(LoginDTO user);
    }
}
