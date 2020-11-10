using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Persistence.Configurations
{
    class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.Property(e => e.LessonDate)
               .IsRequired();

            builder.Property(e => e.LessonNumber)
               .IsRequired();

            builder.Property(e => e.LessonTimeGap)
               .IsRequired();

            builder.HasOne(e => e.Teacher)
                .WithMany(e => e.Lessons)
                .HasForeignKey(e => e.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Groupe)
                .WithMany(e => e.Lessons)
                .HasForeignKey(e => e.GroupeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Discipline)
                .WithMany(e => e.Lessons)
                .HasForeignKey(e => e.DisciplineId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Auditorium)
                .WithMany(e => e.Lessons)
                .HasForeignKey(e => e.AuditoriumId);

            builder.HasData(
                //Monday                
                new Lesson()
                {
                    Id = 1,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 3, 9),
                    LessonTimeGap = "8:00-9:20",
                    AuditoriumId = 1,
                    DisciplineId = 1,
                    TeacherId = 45,
                    GroupeId = 5
                },
                new Lesson()
                {
                    Id = 2,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 3, 9),
                    LessonTimeGap = "9:35-10:55",
                    AuditoriumId = 2,
                    DisciplineId = 4,
                    TeacherId = 4,
                    GroupeId = 5
                },
                new Lesson()
                {
                    Id = 3,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 3, 9),
                    LessonTimeGap = "11:10-12:30",
                    AuditoriumId = 3,
                    DisciplineId = 5,
                    TeacherId = 42,
                    GroupeId = 5
                },
                new Lesson()
                {
                    Id = 4,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 3, 9),
                    LessonTimeGap = "13:30-14:50",
                    AuditoriumId = 4,
                    DisciplineId = 11,
                    TeacherId = 45,
                    GroupeId = 5
                },
                new Lesson()
                {
                    Id = 5,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 3, 9),
                    LessonTimeGap = "15:05-16:25",
                    AuditoriumId = 5,
                    DisciplineId = 10,
                    TeacherId = 42,
                    GroupeId = 5
                },
                new Lesson()
                {
                    Id = 6,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 3, 9),
                    LessonTimeGap = "8:00-9:20",
                    AuditoriumId = 6,
                    DisciplineId = 10,
                    TeacherId = 43,
                    GroupeId = 5
                },

                //Tuesday
                new Lesson()
                {
                    Id = 7,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 3, 10),
                    LessonTimeGap = "9:35-10:55",
                    AuditoriumId = 1,
                    DisciplineId = 11,
                    TeacherId = 44,
                    GroupeId = 5
                },
                new Lesson()
                {
                    Id = 8,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 3, 10),
                    LessonTimeGap = "11:10-12:30",
                    AuditoriumId = 2,
                    DisciplineId = 1,
                    TeacherId = 45,
                    GroupeId = 5
                },
                new Lesson()
                {
                    Id = 9,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 3, 10),
                    LessonTimeGap = "13:30-14:50",
                    AuditoriumId = 3,
                    DisciplineId = 4,
                    TeacherId = 42,
                    GroupeId = 5
                },
                new Lesson()
                {
                    Id = 10,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 3, 10),
                    LessonTimeGap = "15:05-16:25",
                    AuditoriumId = 4,
                    DisciplineId = 5,
                    TeacherId = 43,
                    GroupeId = 5
                }
            );
        }
    }
}
