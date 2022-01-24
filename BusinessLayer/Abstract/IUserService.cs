using BaseCore.Entities.Concrete;
using BaseCore.Entities.Concrete.Dtos.BaseDto;
using BaseCore.Entities.Concrete.Dtos.ListDto;
using BaseCore.Models;
using BusinessLayer.Repositories.Abstract;
using EntityLayer.Entities.DTOs.BaseDto.UserDto;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IUserService : IServiceRepository<UserDto>
    {
        Task<PagedList<UsersDto>> GetAllAsync(Filter filter);
        Task<UserDto> GetByMail(string email);
        Task EditProfile(EditDto user);
        List<OperationClaim> GetClaims(User user);
    }
}