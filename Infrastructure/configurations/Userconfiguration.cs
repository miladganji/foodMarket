using Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.configurations
{
    public class Userconfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasIndex(a => a.Mobile).IsUnique();
            
            builder.Property(a => a.FirsName).HasMaxLength(300).IsRequired();
            builder.Property(a => a.LastName).HasMaxLength(600).IsRequired();
            builder.Property(a => a.Mobile).HasMaxLength(15).IsRequired();
            builder.Property(a => a.Password).HasMaxLength(300).IsRequired().IsUnicode(true);





        }
    }
}
