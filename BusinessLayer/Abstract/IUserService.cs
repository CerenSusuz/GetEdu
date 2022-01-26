using BaseCore.Entities.Concrete;
using BaseCore.Entities.Concrete.Dtos.BaseDto;
using BaseCore.Entities.Concrete.Dtos.ListDto;
using BaseCore.Models;
using BaseCore.Utilities.Results.Abstract;
using BusinessLayer.Repositories.Abstract;
using EntityLayer.Entities.DTOs.BaseDto.UserDto;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IUserService : IServiceRepository<User, UserDto>
    {
        IDataResult<List<UsersDto>> GetAll();
        IDataResult<User> GetByMail(string email);
        IResult EditProfile(EditDto user);
        IDataResult<List<OperationClaim>> GetClaims(User user);
    }
}