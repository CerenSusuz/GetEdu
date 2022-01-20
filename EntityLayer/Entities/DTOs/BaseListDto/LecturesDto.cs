using BaseCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.DTOs.BaseListDto
{
    public class LecturesDto : IListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Preview { get; set; }
        public DateTime Duration { get; set; }

        public string Image { get; set; }
        public string Section { get; set; }
    }
}
