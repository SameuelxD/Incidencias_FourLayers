using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class TuitionConfiguration : IEntityTypeConfiguration<Tuition>
    {
        public void Configure(EntityTypeBuilder<Tuition> builder)
        {
            builder.ToTable("Tuition");
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.People)
            .WithMany(e => e.Tuitions)
            .HasForeignKey(e => e.IdPerson);

            builder.HasOne(e => e.Courses)
            .WithMany(e => e.Tuitions)
            .HasForeignKey(e => e.IdCourse);
        }
    }
}