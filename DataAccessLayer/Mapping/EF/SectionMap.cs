using EntityLayer.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Mapping
{
    public class SectionMap : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.Property(sec => sec.Title).IsRequired().HasMaxLength(50);
            builder.Property(sec => sec.ContentId).IsRequired();
            builder.HasOne(sec => sec.Content)
                .WithMany(x => x.Sections)
                .HasForeignKey(x => x.ContentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
