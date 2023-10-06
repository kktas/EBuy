using EBuy.Core.Models;
using EBuy.Data.Constants;
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
                .HasMaxLength(ConfigurationConstants.NameLength);

            builder.Property(b => b.Address)
                .IsRequired()
                .HasMaxLength(ConfigurationConstants.AddressLength);

            builder.Property(b => b.PhoneNumber)
                .IsRequired()
                .HasMaxLength(ConfigurationConstants.PhoneLength);

            builder.ToTable("t_business");
        }
    }
}
