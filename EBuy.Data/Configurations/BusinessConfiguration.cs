using EBuy.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EBuy.Data.Configurations
{
    public class BusinessConfiguration : BaseConfiguration<Business>
    {

        public override void Configure(EntityTypeBuilder<Business> builder)
        {
            base.Configure(builder);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(b => b.Address)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(b => b.PhoneNumber)
                .IsRequired()
                .HasMaxLength(16);

            builder.ToTable("t_business");
        }
    }
}
