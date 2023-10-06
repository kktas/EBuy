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
    public class CategoryConfiguration : BaseConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(ConfigurationConstants.NameLength);

            builder.HasOne(c => c.ParentCategory)
                .WithMany(p => p.ChildCategories)
                .HasForeignKey(c => c.ParentCategoryId);

            builder.ToTable("t_category");
        }
    }
}
