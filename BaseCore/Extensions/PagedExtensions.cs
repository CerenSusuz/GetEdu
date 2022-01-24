using AutoMapper;
using BaseCore.Entities.Abstract;
using BaseCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCore.Extensions
{
    public static class PagedExtensions
    {
        public static PagedList<TDto> ToPagedList<TEntity, TDto>(this IQueryable<TEntity> source, Filter filter, IMapper mapper)
            where TDto : class, IListDto, new()
            where TEntity : class, IEntity, new()
        {
            var count = source.Count();

            var entities = source.OrderBy(filter).SkipTake(filter).ToList();

            var result = mapper.Map<List<TDto>>(entities);
            return new PagedList<TDto>(result, count, filter);
        }
    }
}
