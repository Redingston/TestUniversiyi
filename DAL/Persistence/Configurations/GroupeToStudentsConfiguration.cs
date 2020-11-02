using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Persistence.Configurations
{
    class GroupeToStudentsConfiguration: IEntityTypeConfiguration<GroupeToStudent>
    {
        public void Configure(EntityTypeBuilder<GroupeToStudent> builder)
        {
            builder.HasKey(x => new { x.GroupeId, x.StudentId });

            builder.HasOne(e => e.Student)
                .WithMany(e => e.GroupeToStudents)
                .HasForeignKey(e => e.StudentId)
                .IsRequired();

            builder.HasOne(e => e.Groupe)
                .WithMany(e => e.GroupeToStudents)
                .HasForeignKey(e => e.GroupeId)
                .IsRequired();

            builder.HasData(
                new GroupeToStudent
                {
                    GroupeId = 1,
                    StudentId = 15
                }
            );
        }
    }
}
