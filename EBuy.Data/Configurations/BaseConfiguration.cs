using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBuy.Data.Configurations
{
    public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : class
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {

            if (builder.Metadata.FindProperty("Id") != null)
            {
                builder.HasKey("Id");

                builder.Property("Id")
                    .UseIdentityColumn();
            }

            if (builder.Metadata.FindProperty("CreatedAt") != null)
            {
                builder.Property("CreatedAt")
                    .IsRequired();
            }

            if (builder.Metadata.FindProperty("CreatedBy") != null)
            {
                builder.Property("CreatedBy")
                    .IsRequired();
            }
        }
    }
}
