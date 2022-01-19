using BaseCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.Concrete
{
    public class Lecture : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Title { get; set; }
        public string? Preview { get; set; }
        public DateTime Duration { get; set; }

        //one lecture has one image
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
