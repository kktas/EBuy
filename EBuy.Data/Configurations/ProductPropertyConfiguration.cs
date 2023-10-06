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
    public class ProductPropertyConfiguration : BaseConfiguration<ProductProperty>
    {
        public override void Configure(EntityTypeBuilder<ProductProperty> builder)
        {
            base.Configure(builder);

            builder.Property(pp => pp.Name)
                .IsRequired()
                .HasMaxLength(ConfigurationConstants.NameLength);

            builder.HasOne(pp => pp.ProductPropertyType)
                .WithMany(ppt => ppt.ProductProperties)
                .HasForeignKey(pp => pp.ProductPropertyTypeId);

            builder.ToTable("t_product_property");
        }
    }
}
