using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");
            builder.HasKey(e => e.IdPerson);
            builder.Property(e => e.IdPerson)
            .HasMaxLength(20)
            .IsRequired();

            builder.Property(e => e.Name)
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(e => e.LastName)
            .HasMaxLength(50)
            .IsRequired();

            builder.HasOne(e => e.Genders)
            .WithMany(e => e.People)
            .HasForeignKey(e => e.IdGenre);

            builder.HasOne(e => e.Cities)
            .WithMany(e => e.People)
            .HasForeignKey(e => e.IdCity);

            builder.HasOne(e => e.TypePeople)
            .WithMany(e => e.People)
            .HasForeignKey(e => e.IdTypePerson);
            



        }
    }
}