using BaseCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.DTOs.BaseDtos
{
    public class LectureDto : IDto
    {
        public string Title { get; set; }
        public string? Preview { get; set; }
        public DateTime Duration { get; set; }

        public int ImageId { get; set; }
        public int SectionId { get; set; }
    }
}
