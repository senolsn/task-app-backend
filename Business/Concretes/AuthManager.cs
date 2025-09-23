using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Business.Dtos.Request.Auth;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, IMapper mapper, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
        }

        public async Task<IDataResult<AccessToken>> CreateAccessToken(User user)
        {
            var claims = await _userService.GetClaims(user);
            var accessToken = await _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken,Messages.AccessTokenCreated);
        }

        public async Task<IDataResult<User>> Login(CreateLoginRequest request)
        {
            var userToCheck = await _userService.GetByMail(request.Email);
            
            if(userToCheck is null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if(!HashingHelper.VerifyPasswordHash(request.Password, userToCheck.PasswordHash,userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.WrongMailOrPassword);
            }

            return new SuccessDataResult<User>(userToCheck,Messages.Loginned);
        }

        public async Task<IDataResult<User>> Register(CreateRegisterRequest request)
        {
            var userExists = await CheckUserExists(request.Email);

            if(!userExists) 
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
                var user = new User { PasswordHash = passwordHash, PasswordSalt = passwordSalt };

                var mappedUser = _mapper.Map(request, user);
                await _userService.Add(mappedUser, request);

                return new SuccessDataResult<User>(user);
            }

            return new ErrorDataResult<User>();
        }

        private async Task<bool> CheckUserExists(string mail)
        {
            var result = await _userService.GetByMail(mail);

            if (result is not null)
            {
                return true;
            }
            return false;
        }
    }
}
