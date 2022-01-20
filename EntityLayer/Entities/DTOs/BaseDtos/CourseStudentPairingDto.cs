using BaseCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.DTOs.BaseDto
{
    public class CourseStudentPairingDto : IDto
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
    }
}
