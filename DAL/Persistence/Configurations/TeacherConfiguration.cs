using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Persistence.Configurations
{
    class TeacherConfiguration: IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(e => e.Degree)
                .HasMaxLength(256);

            builder.HasOne(e => e.User)
                .WithOne(e => e.Teacher)
                .HasForeignKey<Teacher>(e => e.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Groupes)
                .WithOne(e => e.TeacherOf);

            builder.HasMany(e => e.Lessons)
                .WithOne(e => e.Teacher);

            builder.HasMany(e => e.TeacherToDisciplines)
                .WithOne(e => e.Teacher);

            builder.HasData(
                new Teacher
                {
                    Id = 1,
                    Degree = "Computer science"
                },
                new Teacher
                {
                    Id = 2,
                    Degree = "Economy"
                },
                new Teacher
                {
                    Id = 3,
                    Degree = "Mathematics"
                },
                new Teacher { Id = 14 }, //head-assistant
                new Teacher { Id = 15 }, //master
                new Teacher { Id = 16 } //head-master
            );
        }
    }
}
