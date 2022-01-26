using BaseCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCore.Models
{
    public class PagedList<TDto>
        where TDto : class, IListDto, new()
    {

        public List<TDto> Data { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public string LastCachedDate { get; set; }


        public PagedList()
        {

        }


        public PagedList(List<TDto> data, int count)
        {
            TotalCount = count;
            Data = data;
            LastCachedDate = DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss");
        }
    }
}

