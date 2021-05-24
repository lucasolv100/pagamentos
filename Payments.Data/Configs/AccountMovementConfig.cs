using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payments.Domain.Entities;

namespace Payments.Data.Configs
{
    public class AccountMovementConfig : IEntityTypeConfiguration<AccountMovement>
    {
        public void Configure(EntityTypeBuilder<AccountMovement> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Value).IsRequired().HasColumnType("decimal(10,2)");
            builder.Property(p => p.MovementType).IsRequired();
            builder.Property(p => p.CreateDate).IsRequired();
            builder.Property(p => p.EditDate).IsRequired(false);
            builder.Property(p => p.DeleteDate).IsRequired(false);

            builder.HasOne(x => x.Account)
                .WithMany(x => x.Movements)
                .HasForeignKey(x => x.AccountId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Ignore(i => i.CascadeMode);
        }
    }

}