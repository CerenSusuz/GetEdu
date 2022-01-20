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
    public class LectureMap : IEntityTypeConfiguration<Lecture>
    {
        public void Configure(EntityTypeBuilder<Lecture> builder)
        {
            builder.Property(ins => ins.Title).IsRequired().HasMaxLength(50);
            builder.Property(ins => ins.Preview).IsRequired().HasMaxLength(100);
            builder.HasIndex(ins => ins.ImageId).IsUnique();
            builder.HasOne(ins => ins.Section)
                .WithMany(ins => ins.Lectures)
                .HasForeignKey(ins => ins.SectionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
