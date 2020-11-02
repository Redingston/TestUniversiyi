using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Persistence.Configurations
{
    class GroupeConfiguration : IEntityTypeConfiguration<Groupe>
    {
        public void Configure(EntityTypeBuilder<Groupe> builder)
        {
            builder.Property(e => e.Number)
                .HasMaxLength(3);

            builder.Property(e => e.Character)
                .IsRequired()
                .HasMaxLength(7);

            builder.HasOne(x => x.TeacherOf)
                .WithMany(x => x.Groupes)
                .HasForeignKey(x => x.GroupeTeacherId);

            builder.HasMany(e => e.GroupeToStudents)
                .WithOne(e => e.Groupe);

            builder.HasMany(e => e.GroupeToDisciplines)
                .WithOne(e => e.Groupe);

            builder.HasData(
                new Groupe
                {
                    Id = 1,
                    Number = 111,
                    Character = "CS",
                    GroupeTeacherId = 1
                },
                new Groupe
                {
                    Id = 2,
                    Number = 571,
                    Character = "CB",
                    GroupeTeacherId = 1
                },
                new Groupe
                {
                    Id = 3,
                    Number = 221,
                    Character = "AA",
                    GroupeTeacherId = 2
                }
            );
        }
    }
}
