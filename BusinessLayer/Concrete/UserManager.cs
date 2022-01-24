
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BaseCore.Aspects.Caching;
using BaseCore.Aspects.Validation;
using BaseCore.DataAccess.EntityFramework;
using BaseCore.Entities.Concrete;
using BaseCore.Entities.Concrete.Dtos.BaseDto;
using BaseCore.Entities.Concrete.Dtos.ListDto;
using BaseCore.Extensions;
using BaseCore.Models;
using BaseCore.Utilities.Security.Hashing;
using BusinessLayer.Abstract;
using BusinessLayer.Repositories.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Entities.DTOs.BaseDto.UserDto;

namespace BusinessLayer.Concrete
{
    [ValidationAspect(typeof(UserValidator))]
    public class UserManager : ServiceRepository<User, UserDto>, IUserService
    {
        private readonly IEntityRepository<User> _repository;
        private readonly IMapper _mapper;
        private readonly IUserDAL _userDAL;
        public UserManager(IEntityRepository<User> repository, 
            IMapper mapper,
            IUserDAL userDAL
            ) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _userDAL = userDAL;
        }

        [CacheAspect]
        public async Task EditProfile(EditDto user)
        {
            byte[] passwordHash;
            byte[] passwordSalt;

            HashingHelper.CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);
            
            var userInfo = new User()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            await _repository.UpdateAsync(userInfo);
        }

        [CacheAspect]
        public async Task<PagedList<UsersDto>> GetAllAsync(Filter filter)
        {
            return await Task.Run(() => _repository.AsNoTracking()
            .Filter(filter)
            .ToPagedList<User, UsersDto>(filter, _mapper));
        }

        [CacheAspect]
        public async Task<UserDto> GetByMail(string email)
        {
            var entity = await Task.Run(() => 
            _repository.GetAsync(user => user.Email == email));
            return _mapper.Map<UserDto>(entity);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDAL.GetClaims(user);
        }
    }
}

