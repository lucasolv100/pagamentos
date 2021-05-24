using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payments.Domain.Entities;

namespace Payments.Data.Configs
{
    public class AccountConfig : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Document).IsRequired().HasMaxLength(14);
            builder.Property(p => p.CreateDate).IsRequired();
            builder.Property(p => p.EditDate).IsRequired(false);
            builder.Property(p => p.DeleteDate).IsRequired(false);
            builder.Property(p => p.IsLegalPerson).IsRequired();
        }
    }

}