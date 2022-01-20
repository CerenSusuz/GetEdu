using BaseCore.Entities.Abstract;
using BaseCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.Concrete
{
    public class Lecture : BaseEntity
    {
        public string Title { get; set; }
        public string? Preview { get; set; }
        public DateTime Duration { get; set; }

        //one lecture has one image
        public int ImageId { get; set; }
        public Image Image { get; set; }
        public int SectionId { get; set; }
        public Section Section { get; set; }
    }
}
