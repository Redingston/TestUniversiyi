using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Persistence.Configurations
{
    class GroupeToDisciplineConfiguration : IEntityTypeConfiguration<GroupeToDiscipline>
    {
        public void Configure(EntityTypeBuilder<GroupeToDiscipline> builder)
        {
            builder.HasKey(x => new { x.GroupeId, x.DisciplineId });

            builder.HasOne(e => e.Discipline)
                .WithMany(e => e.GroupeToDisciplines)
                .HasForeignKey(e => e.DisciplineId)
                .IsRequired();

            builder.HasOne(e => e.Groupe)
                .WithMany(e => e.GroupeToDisciplines)
                .HasForeignKey(e => e.GroupeId)
                .IsRequired();

            builder.HasData(
                new GroupeToDiscipline() { GroupeId = 1, DisciplineId = 1 },
                new GroupeToDiscipline() { GroupeId = 1, DisciplineId = 10 },
                new GroupeToDiscipline() { GroupeId = 1, DisciplineId = 11 },
                new GroupeToDiscipline() { GroupeId = 2, DisciplineId = 1 },
                new GroupeToDiscipline() { GroupeId = 2, DisciplineId = 8 },
                new GroupeToDiscipline() { GroupeId = 2, DisciplineId = 9 },
                new GroupeToDiscipline() { GroupeId = 2, DisciplineId = 11 },
                new GroupeToDiscipline() { GroupeId = 3, DisciplineId = 1 },
                new GroupeToDiscipline() { GroupeId = 3, DisciplineId = 5 },
                new GroupeToDiscipline() { GroupeId = 3, DisciplineId = 6 },
                new GroupeToDiscipline() { GroupeId = 3, DisciplineId = 7 }
            );
        }
    }
}
