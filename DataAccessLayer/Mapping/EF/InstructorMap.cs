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
    public class InstructorMap : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.Property(ins => ins.Title).IsRequired().HasMaxLength(50);
            builder.Property(ins => ins.Description).IsRequired().HasMaxLength(125);
            builder.Property(ins => ins.CurriculumVitae).IsRequired().HasMaxLength(256);
            builder.HasIndex(ins => ins.WebSite).IsUnique();
            builder.HasIndex(stu => stu.InstructorId).IsUnique();
            builder.HasIndex(stu => stu.Email).IsUnique();
            builder.HasIndex(stu => stu.ImageId).IsUnique();
        }
    }
}
