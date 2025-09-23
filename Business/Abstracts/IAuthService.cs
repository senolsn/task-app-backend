using Business.Dtos.Request.Auth;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IAuthService
    {
        Task<IDataResult<User>> Register(CreateRegisterRequest request);
        Task<IDataResult<User>> Login(CreateLoginRequest request);
        Task<IDataResult<AccessToken>> CreateAccessToken(User user);
    }
}
