using EBuy.Core.Models;
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
                .HasMaxLength(255);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(u => u.Email)
               .IsRequired()
               .HasMaxLength(320);


            builder.Property(u => u.PhoneNumber)
               .IsRequired()
               .HasMaxLength(16);

            builder.Property(u => u.Address)
               .IsRequired()
               .HasMaxLength(255);

            builder.HasOne(u => u.Business)
                .WithMany(b => b.Users)
                .HasForeignKey(u => u.BusinessId);

            builder.ToTable("t_user");

        }
    }
}
