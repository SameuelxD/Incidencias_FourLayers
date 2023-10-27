using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Gender");
            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.Name)
            .HasMaxLength(10)
            .IsRequired();

            builder.Property(e => e.Description)
            .HasMaxLength(200);
        }
    }
}