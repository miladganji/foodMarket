using Domain.Food;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.configurations
{
    public class Foodconfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {

            builder.HasIndex(a => a.FoodName).IsUnique();
            builder.Property(a => a.FoodName).HasMaxLength(200).IsRequired();
            builder.OwnsOne(a => a.price);
        }
    }
}
