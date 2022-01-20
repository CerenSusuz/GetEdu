using EntityLayer.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Mapping
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");
            builder.HasIndex(acc => acc.Email).IsUnique();
            builder.HasData(new Account
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "User",
                Email = "admin@cerensusuz.com",
            });
        }
    }
}