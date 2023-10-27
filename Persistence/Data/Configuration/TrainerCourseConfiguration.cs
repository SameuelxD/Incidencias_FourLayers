
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class TrainerCourseConfiguration : IEntityTypeConfiguration<TrainerCourse>
    {
        public void Configure(EntityTypeBuilder<TrainerCourse> builder)
        {
            builder.ToTable("TrainerCourse");
            builder.HasKey(e => new{e.IdPerson,e.IdCourse});

            builder.HasOne(e => e.People)
            .WithMany(e => e.TrainerCourses)
            .HasForeignKey(e => e.IdPerson);

            builder.HasOne(e => e.Courses)
            .WithMany(e => e.TrainerCourses)
            .HasForeignKey(e => e.IdCourse);
        }
    }
}