using BaseCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.DTOs.BaseDtos
{
    public class SocialMedaAccountDto : IDto
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public int InstructorId { get; set; }
    }
}
