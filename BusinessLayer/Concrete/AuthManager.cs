using AutoMapper;
using BaseCore.Entities.Concrete;
using BaseCore.Entities.Concrete.Dtos.BaseDto;
using BaseCore.Entities.Concrete.Dtos.ListDto;
using BaseCore.Utilities.Security.Hashing;
using BaseCore.Utilities.Security.JWT;
using BusinessLayer.Abstract;
using EntityLayer.Entities.DTOs.BaseDto.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;
        private readonly IMapper _mapper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IMapper mapper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _mapper = mapper;
        }

        public async Task<User> Register(RegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new UserDto()
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            await _userService.InsertAsync(user);
            return _mapper.Map<User>(user);

        }

        public async Task<User> Login(LoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return _mapper.Map<User>(userToCheck);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Result.PasswordHash, userToCheck.Result.PasswordSalt))
            {
                return _mapper.Map<User>(userToCheck);
            }

            return _mapper.Map<User>(userToCheck);
        }

        public async Task<bool> UserExists(string email) 
        {
            if (_userService.GetByMail(email) != null)
            {
                return true;
            }
            return false;
        }

        public async Task<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user,claims);
            return (accessToken);
        }

    }
}
