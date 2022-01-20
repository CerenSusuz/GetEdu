using BaseCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.DTOs.BaseDtos
{
    public class InstructorDto : IDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CurriculumVitae { get; set; }
        public string WebSite { get; set; }

        public int AccountId { get; set; }
    }
}
