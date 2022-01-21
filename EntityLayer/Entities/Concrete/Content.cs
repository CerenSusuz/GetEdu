using BaseCore.Entities.Abstract;
using BaseCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.Concrete
{
    public class Content : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime TotalLength { get; set; }

        //one content has many sections
        public ICollection<Section> Sections { get; set; }
    }
}
