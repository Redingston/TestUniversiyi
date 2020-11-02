using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Persistence.Configurations
{
    class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(x => x.TeacherToDisciplines)
                .WithOne(x => x.Discipline);

            builder.HasMany(e => e.Lessons)
                .WithOne(e => e.Discipline);

            builder.HasMany(e => e.GroupeToDisciplines)
                .WithOne(e => e.Discipline);

            builder.HasOne(e => e.University)
                .WithMany(e => e.Disciplines)
                .HasForeignKey(e => e.UniversityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Discipline { Id = 1, UniversityId = 1, Name = "English" },
                new Discipline { Id = 2, UniversityId = 1, Name = "History of Ukraine" },
                new Discipline { Id = 3, UniversityId = 1, Name = "World History" },
                new Discipline { Id = 4, UniversityId = 1, Name = "Fundamentals of Law" },
                new Discipline { Id = 5, UniversityId = 1, Name = "Economy" },
                new Discipline { Id = 6, UniversityId = 1, Name = "Microeconomy" },
                new Discipline { Id = 7, UniversityId = 1, Name = "Philosophy" },
                new Discipline { Id = 8, UniversityId = 1, Name = "Physics" },
                new Discipline { Id = 9, UniversityId = 1, Name = "Chemistry" },
                new Discipline { Id = 10, UniversityId = 1, Name = "Computer Science" },
                new Discipline { Id = 11, UniversityId = 1, Name = "Higher mathematics" }
            );
        }
    }
}
