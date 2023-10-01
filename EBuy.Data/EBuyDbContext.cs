using EBuy.Core.Models;
using EBuy.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBuy.Data
{
    public class EBuyDbContext : DbContext
    {
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProperty> CategoryProperties { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }
        public DbSet<User> Users { get; set; }
        public EBuyDbContext(DbContextOptions<EBuyDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BusinessConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new CategoryPropertyConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProductPropertyConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());

            builder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    FirstName = "Ali",
                    LastName = "Veli",
                    Address = "Acıbadem, 34660 Üsküdar/İstanbul",
                    Email = "ebuyaliveli@gmail.com",
                    Business = null,
                    PhoneNumber = "+901234567890",
                    Password = "1234567890"
                }
            );
        }
    }
}
