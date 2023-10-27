using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country");
            builder.HasKey(e => e.IdCountry);
            builder.Property(e => e.IdCountry)
            .HasMaxLength(3)
            .IsRequired();

            builder.Property(e => e.Name)
            .HasMaxLength(30)
            .IsRequired();
        }
    }
}