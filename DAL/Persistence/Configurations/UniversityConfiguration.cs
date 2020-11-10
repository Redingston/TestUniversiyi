using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Persistence.Configurations
{
    class UniversityConfiguration: IEntityTypeConfiguration<University>
    {
        public void Configure(EntityTypeBuilder<University> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.ShortName)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(e => e.Auditoriums)
                .WithOne(e => e.University);

            builder.HasMany(e => e.Disciplines)
                .WithOne(e => e.University);

            builder.HasData(
                new University
                {
                    Id = 1,
                    Name = "NATIONAL UNIVERSITY OF WATER AND ENVIRONMENTAL ENGINEERING",
                    ShortName = "NUWM",
                    Address = "Soborna 11",
                    Locality = "Rivne",
                    Email = "nuwm@gmail.com"
                }
            );
        }
    }
}
