
using BaseCore.Entities.Concrete;
using BaseCore.Entities.Concrete.Dtos.BaseDto;
using BaseCore.Utilities.Results.Abstract;
using BaseCore.Utilities.Security.JWT;
using EntityLayer.Entities.DTOs.BaseDto.UserDto;

namespace BusinessLayer.Abstract
{

    public interface IAuthService
    {
        IDataResult<User> Register(RegisterDto userForRegisterDto);
        IDataResult<User> Login(LoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}