using BaseCore.Entities.Abstract;
using BaseCore.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories.Abstract
{
    public interface IServiceRepository<TEntity,TDto>
        where TDto : class, IDto, new()
    {
        /// <summary>
        /// Get Model  by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IDataResult<TDto> GetById(int id);

        /// <summary>
        /// Insert Entity
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        IResult Insert(TDto dto);

        /// <summary>
        /// Update Entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        IResult Update(int id, TDto dto);

        /// <summary>
        /// Delete Entity By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IResult Delete(int id);


    }
}
