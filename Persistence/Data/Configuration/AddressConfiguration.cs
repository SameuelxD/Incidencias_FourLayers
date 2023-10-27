using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.ViaType)
              .IsRequired()
              .HasMaxLength(20);
            builder.Property(e => e.Number)
              .IsRequired()
              .HasColumnType("int");
            builder.Property(e => e.Letter)
              .IsRequired()
              .HasMaxLength(1);
            builder.Property(e => e.CardinalSuffix)
              .IsRequired()
              .HasMaxLength(30);
            builder.Property(e => e.SecondaryRoadNumber)
              .HasColumnType("int"); 
            builder.Property(e => e.SecondaryRoadLetter)
              .HasMaxLength(1);
            builder.Property(e => e.CardsSuffix)
              .HasMaxLength(10);

            builder.HasOne(e => e.People)
            .WithMany(e => e.Addresses)
            .HasForeignKey(e => e.IdPerson);     
        }
    }
}