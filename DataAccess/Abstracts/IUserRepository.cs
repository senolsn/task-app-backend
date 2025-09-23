using Core.DataAccess.Repositories;
using Core.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;
using User = Core.Entities.Concrete.User;

namespace DataAccess.Abstracts
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<List<OperationClaim>> GetClaims(User user);
    }
}
