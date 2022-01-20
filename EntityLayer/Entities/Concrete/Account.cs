using System.Collections.Generic;
using BaseCore.Entities.Abstract;
using BaseCore.Entities.Concrete;
using EntityLayer.Entities.Concrete;

namespace EntityLayer.Entities.Concrete
{
    public class Account : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}