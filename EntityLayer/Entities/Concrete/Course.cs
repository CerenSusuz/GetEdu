using BaseCore.Entities.Abstract;
using BaseCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.Concrete
{
    public  class Course : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Rate { get; set; }
        public double Price { get; set; }

        //one course -> one instructor and image
        public int InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
