using EntityLayer.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Mapping
{
    public class SocialMediaAccountMap : IEntityTypeConfiguration<SocialMediaAccount>
    {
        public void Configure(EntityTypeBuilder<SocialMediaAccount> builder)
        {
            builder.HasIndex(media => media.Url).IsUnique();
            builder.HasIndex(media => media.InstructorId).IsUnique(); 
            builder.Property(media => media.Url).IsRequired().HasMaxLength(50);
            builder.HasOne(media => media.Instructor)
                .WithMany(x => x.SocialMediaAccounts)
                .HasForeignKey(x => x.InstructorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
