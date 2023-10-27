using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City");
            builder.HasKey(e => e.IdCity);
            builder.Property(e => e.IdCity)
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired();
            
            builder.HasOne(e => e.Departments)
            .WithMany(e => e.Cities)
            .HasForeignKey(e => e.IdDepartment);
        }
    }
}