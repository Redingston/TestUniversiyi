using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Persistence.Configurations
{
    class StudentConfiguration: IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasOne(e => e.User)
                .WithOne(e => e.Student)
                .HasForeignKey<Student>(e => e.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.GroupeToStudents)
                .WithOne(e => e.Student);
            builder.HasData(
                new Student { Id = 4 },
                new Student { Id = 5 },
                new Student { Id = 6 },
                new Student { Id = 7 },
                new Student { Id = 8 },
                new Student { Id = 9 },
                new Student { Id = 10 },
                new Student { Id = 11 },
                new Student { Id = 12 },
                new Student { Id = 13 }
            );
        }
    }
}
