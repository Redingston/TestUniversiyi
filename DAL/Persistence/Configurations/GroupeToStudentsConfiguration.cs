using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Persistence.Configurations
{
    class GroupeToStudentsConfiguration : IEntityTypeConfiguration<GroupeToStudent>
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
                    StudentId = 4
                },
                new GroupeToStudent
                {
                    GroupeId = 1,
                    StudentId = 5
                },
                new GroupeToStudent
                {
                    GroupeId = 1,
                    StudentId = 6
                }, new GroupeToStudent
                {
                    GroupeId = 1,
                    StudentId = 7
                }, new GroupeToStudent
                {
                    GroupeId = 1,
                    StudentId = 8
                }, new GroupeToStudent
                {
                    GroupeId = 1,
                    StudentId = 9
                }, new GroupeToStudent
                {
                    GroupeId = 2,
                    StudentId = 10
                }, new GroupeToStudent
                {
                    GroupeId = 2,
                    StudentId = 11
                },
                new GroupeToStudent
                {
                    GroupeId = 2,
                    StudentId = 12
                }, new GroupeToStudent
                {
                    GroupeId = 2,
                    StudentId = 13
                }
            );
        }
    }
}
