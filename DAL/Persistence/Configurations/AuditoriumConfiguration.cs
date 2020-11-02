using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Persistence.Configurations
{
    class AuditoriumConfiguration : IEntityTypeConfiguration<Auditorium>
    {
        public void Configure(EntityTypeBuilder<Auditorium> builder)
        {
            builder.Property(e => e.Number)
                .HasMaxLength(5);

            builder.Property(e => e.Name)
                .HasMaxLength(50);

            builder.HasOne(e => e.University)
                .WithMany(e => e.Auditoriums)
                .HasForeignKey(e => e.UniversityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Lessons)
                .WithOne(e => e.Auditorium);

            builder.HasData(
                new Auditorium
                {
                    Id = 1,
                    UniversityId = 1,
                    Number = 101,
                    Name = "Historical"
                }, 
                new Auditorium
                {
                    Id = 2,
                    UniversityId = 1,
                    Number = 102,
                    Name = "Mathematical"
                },
                new Auditorium
                {
                    Id = 3,
                    UniversityId = 1,
                    Number = 103,
                    Name = "Economical"
                },
                new Auditorium
                {
                    Id = 4,
                    UniversityId = 1,
                    Number = 104,
                    Name = "Legal"
                },
                new Auditorium
                {
                    Id = 5,
                    UniversityId = 1,
                    Number = 105,
                    Name = "Chimical"
                }
            );
        }
    }

}
