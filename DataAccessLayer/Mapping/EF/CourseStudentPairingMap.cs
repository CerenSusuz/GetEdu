using EntityLayer.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mapping
{
    public class CourseStudentPairingMap : IEntityTypeConfiguration<CourseStudentPairing>
    {
        public void Configure(EntityTypeBuilder<CourseStudentPairing> builder)
        {
            builder.HasIndex(cs => new { cs.CourseId, cs.StudentId }).IsUnique();
        }
    }
}
