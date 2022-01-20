using BaseCore.Entities.Abstract;
using BaseCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.Concrete
{
    public class Section : BaseEntity
    {
        public string Title { get; set; }

        public int ContentId { get; set; }
        public Content Content { get; set; }
        //one section many lectures
        public ICollection<Lecture> Lectures { get; set; }
    }
}
