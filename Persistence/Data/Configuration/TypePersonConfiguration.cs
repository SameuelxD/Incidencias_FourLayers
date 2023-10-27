using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class TypePersonConfiguration : IEntityTypeConfiguration<TypePerson>
    {
        public void Configure(EntityTypeBuilder<TypePerson> builder)
        {
            builder.ToTable("TypePerson");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Description)
            .HasMaxLength(50)
            .IsRequired();
        }
    }
}

