using BaseCore.Entities.Abstract;
using BaseCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.Concrete
{
    public class SocialMediaAccount : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
    }
}
