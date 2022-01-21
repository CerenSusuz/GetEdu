using BaseCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.DTOs.BaseDtos
{
    public class CourseDto : IDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public decimal Price { get; set; }

        public int InstructorId { get; set; }
        public int ImageId { get; set; }
    }
}
