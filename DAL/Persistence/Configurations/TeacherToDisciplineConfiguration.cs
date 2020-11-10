using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Persistence.Configurations
{
    class TeacherToDisciplineConfiguration : IEntityTypeConfiguration<TeacherToDiscipline>
    {
        public void Configure(EntityTypeBuilder<TeacherToDiscipline> builder)
        {
            builder.HasKey(x => new { x.DisciplineId, x.TeacherId });

            builder.HasOne(e => e.Discipline)
                .WithMany(e => e.TeacherToDisciplines)
                .HasForeignKey(e => e.DisciplineId);

            builder.HasOne(e => e.Teacher)
                .WithMany(e => e.TeacherToDisciplines)
                .HasForeignKey(e => e.TeacherId);

            builder.HasData(
                new TeacherToDiscipline { DisciplineId = 1, TeacherId = 1 },
                new TeacherToDiscipline { DisciplineId = 4, TeacherId = 2 },
                new TeacherToDiscipline { DisciplineId = 5, TeacherId = 3 },
                new TeacherToDiscipline { DisciplineId = 10, TeacherId = 14 },
                new TeacherToDiscipline { DisciplineId = 11, TeacherId = 16 }
            );
        }
    }
}
