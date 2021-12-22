using ApiCursoNetCore.Data.Context;
using ApiCursoNetCore.Data.Repository;
using APICursoNetCore.Domain.Entities;
using APICursoNetCore.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ApiCursoNetCore.Data.Implementations
{
    public class UserImplementations : BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> _dataset;

        public UserImplementations(MyContext context) : base(context)
        {
            _dataset = context.Set<UserEntity>();
        }

        public async Task<UserEntity> FindByLogin(string email)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}
