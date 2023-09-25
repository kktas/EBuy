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
    public class ProductPropertyConfiguration : BaseConfiguration<ProductProperty>
    {
        public override void Configure(EntityTypeBuilder<ProductProperty> builder)
        {
            base.Configure(builder);

            builder.Property(pp => pp.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(pp => pp.CategoryProperty)
                .WithMany(ppt => ppt.ProductProperties)
                .HasForeignKey(pp => pp.CategoryPropertyId);

            builder.ToTable("t_product_property");
        }
    }
}
