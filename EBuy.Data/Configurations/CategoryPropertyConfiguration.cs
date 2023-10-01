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
    public class CategoryPropertyConfiguration : BaseConfiguration<CategoryProperty>
    {
        public override void Configure(EntityTypeBuilder<CategoryProperty> builder)
        {
            base.Configure(builder);

            builder.Property(ppt => ppt.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(ppt => ppt.Category)
                .WithMany(c => c.CategoryProperties)
                .HasForeignKey(ppt => ppt.CategoryId);

            builder.ToTable("t_category_property");
        }
    }
}
