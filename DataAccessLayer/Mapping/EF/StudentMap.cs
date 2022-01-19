using EntityLayer.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Mapping
{
    public class StudentMap : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasIndex(stu => stu.StudentId).IsUnique();
            builder.HasIndex(stu => stu.Email).IsUnique();
            builder.HasIndex(stu => stu.ImageId).IsUnique();
        }
    }
}
