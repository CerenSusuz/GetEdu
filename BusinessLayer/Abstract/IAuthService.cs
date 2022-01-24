using BaseCore.Entities.Concrete;
using BaseCore.Entities.Concrete.Dtos.BaseDto;
using BaseCore.Entities.Concrete.Dtos.ListDto;
using BaseCore.Models;
using BaseCore.Utilities.Security.JWT;
using BusinessLayer.Repositories.Abstract;
using EntityLayer.Entities.DTOs.BaseDto.UserDto;

namespace BusinessLayer.Abstract
{

    public interface IAuthService
    {
        Task<User> Register(RegisterDto userForRegisterDto, string password);
        Task<User> Login(LoginDto userForLoginDto);
        Task<bool> UserExists(string email);
        Task<AccessToken> CreateAccessToken(User user);
    }
}