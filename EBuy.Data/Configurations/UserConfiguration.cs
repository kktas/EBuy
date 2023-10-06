using EBuy.Core.Models;
using EBuy.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBuy.Data.Configurations
{
    public class UserConfiguration : BaseConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(ConfigurationConstants.FirstNameLength);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(ConfigurationConstants.LastNameLength);

            builder.Property(u => u.Email)
               .IsRequired()
               .HasMaxLength(ConfigurationConstants.EmailLength);


            builder.Property(u => u.PhoneNumber)
               .IsRequired()
               .HasMaxLength(ConfigurationConstants.PhoneLength);

            builder.Property(u => u.Address)
               .IsRequired()
               .HasMaxLength(ConfigurationConstants.AddressLength);

            builder.HasOne(u => u.Business)
                .WithMany(b => b.Users)
                .HasForeignKey(u => u.BusinessId);

            builder.ToTable("t_user");

        }
    }
}
