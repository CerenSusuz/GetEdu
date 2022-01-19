using BaseCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.Concrete
{
    public class Instructor : User
    {
        public int InstructorId { get; set; }
        public string Title { get; set; }
        public string CurriculumVitae { get; set; }
        public string WebSite { get; set; }

        public int ImageId { get; set; }
        public Image Image { get; set; }

        //one instructor has many courses
        public ICollection<Course> Courses { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<SocialMediaAccount> SocialMediaAccounts { get; set; }
    }
}
