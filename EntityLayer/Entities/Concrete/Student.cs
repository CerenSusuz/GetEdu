using BaseCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.Concrete
{
    public class Student : BaseEntity
    {
        public int AccountId { get; set; }
        public Account Account { get; set; }
        //TODO:
    }
}
