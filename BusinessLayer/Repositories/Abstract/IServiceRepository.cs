using BaseCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories.Abstract
{
    public interface IServiceRepository<TDto>
        where TDto : class, IDto, new()
    {
        /// <summary>
        /// Get Model  by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TDto> GetAsync(int id);

        /// <summary>
        /// Get Model  by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TDto> GetAllAsync(int id);

        /// <summary>
        /// Insert Entity
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<int> InsertAsync(TDto dto);

        /// <summary>
        /// Update Entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task UpdateAsync(int id, TDto dto);

        /// <summary>
        /// Delete Entity By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Delete Entity By List of id
        /// </summary>
        /// <param name="listOfId"></param>
        /// <returns></returns>
       Task DeleteRangeAsync(List<int> listOfId);

        /// <summary>
        ///     Remove Cache
        /// </summary>
        /// <returns></returns>
       Task RemoveCacheAsync();
    }
}
