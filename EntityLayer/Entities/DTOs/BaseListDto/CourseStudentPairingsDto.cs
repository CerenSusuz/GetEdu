using BaseCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.DTOs.BaseListDto
{
    public class CourseStudentPairingsDto : IListDto
    {
        public int Id { get; set; }
        public string Course { get; set; }
        public string Student { get; set; }
    }
}
