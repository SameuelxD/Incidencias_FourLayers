using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");
            builder.HasKey(e => e.IdDepartment);
            builder.Property(e => e.IdDepartment)
            .HasMaxLength(3)
            .IsRequired();

            builder.Property(e => e.Name)
            .HasMaxLength(30)
            .IsRequired();

            builder.HasOne(e => e.Countries)
            .WithMany(e => e.Departments)
            .HasForeignKey(e => e.IdCountry);
        }
    }
}

