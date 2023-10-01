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
    public class ProductPropertyTypeConfiguration : BaseConfiguration<ProductPropertyType>
    {
        public override void Configure(EntityTypeBuilder<ProductPropertyType> builder)
        {
            base.Configure(builder);

            builder.Property(ppt => ppt.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(ppt => ppt.Category)
                .WithMany(c => c.ProductPropertyTypes)
                .HasForeignKey(ppt => ppt.CategoryId);

            builder.ToTable("t_product_property_type");
        }
    }
}
