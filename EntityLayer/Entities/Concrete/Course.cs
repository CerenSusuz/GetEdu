using BaseCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.Concrete
{
    public  class Course : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public decimal Price { get; set; }

        //one course -> one instructor and image
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
