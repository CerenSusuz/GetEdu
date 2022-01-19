using System.Collections.Generic;
using BaseCore.Entities.Concrete;
using EntityLayer.Entities.Concrete;

namespace EntityLayer.Entities.Concrete
{
    public class Account : User
    {
        public int AccountId { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}