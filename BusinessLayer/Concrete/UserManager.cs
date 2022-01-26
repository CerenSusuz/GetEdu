using AutoMapper;
using BaseCore.Aspects.Caching;
using BaseCore.Aspects.Validation;
using BaseCore.Entities.Concrete;
using BaseCore.Entities.Concrete.Dtos.BaseDto;
using BaseCore.Entities.Concrete.Dtos.ListDto;
using BaseCore.Utilities.Results.Abstract;
using BaseCore.Utilities.Results.Concrete;
using BaseCore.Utilities.Security.Hashing;
using BusinessLayer.Abstract;
using BusinessLayer.Aspects;
using BusinessLayer.Repositories.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Contexts.EF;
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

        [CacheRemoveAspect("IUserService.EditProfile")]
        public IResult EditProfile(EditDto user)
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
                Status = true,
                IsBlocked = true
            };

            _repository.Update(userInfo);
            return new SuccessResult();
        }


        [CacheAspect]
        [SecuredOperation("admin")]
        public IDataResult<List<UsersDto>> GetAll()
        {
            var users = _repository.GetAll();
            var entities = _mapper.Map<List<UsersDto>> (users);
            return new SuccessDataResult<List<UsersDto>>(entities);
        }


        [CacheAspect]
        public IDataResult<User> GetByMail(string email)
        {
            var entity = _repository.Get(user => user.Email == email);
            return new SuccessDataResult<User>(entity);
        }

        [CacheAspect]
        public IDataResult<List<OperationClaim>>? GetClaims(User user)
        {
            var result = _userDAL.Get(u => u.Id == user.Id);
            if (result != null)
            {
                var claims = _userDAL.GetClaims(user);
                return new SuccessDataResult<List<OperationClaim>>(claims);
            }
            return null;
           
        }

    }
}

