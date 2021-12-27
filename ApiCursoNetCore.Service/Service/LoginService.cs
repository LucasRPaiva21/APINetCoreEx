using APICursoNetCore.Domain.Entities;
using APICursoNetCore.Domain.Interfaces.Services.User;
using APICursoNetCore.Domain.Repository;
using System.Threading.Tasks;

namespace ApiCursoNetCore.Service.Service
{
    public class LoginService : ILoginService
    {
        private IUserRepository _repository;

        public LoginService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> FindByLogin(UserEntity user)
        {
            var baseUser = new UserEntity();

            if(user != null && !string.IsNullOrEmpty(user.Email))
            {
                return await _repository.FindByLogin(user.Email);
            }
            else
            {
                return null;
            }
        }
    }
}
