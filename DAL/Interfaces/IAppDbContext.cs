using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Groupe> Groupes { get; set; }
        DbSet<Discipline> Disciplines { get; set; }
        DbSet<Lesson> Lessons { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<University> Universities { get; set; }
        DbSet<Teacher> Teachers { get; set; }
        DbSet<TeacherToDiscipline> TeacherToDisciplines { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Auditorium> Auditoriums { get; set; }
        DbSet<GroupeToStudent> GroupeToStudents { get; set; }
        DbSet<GroupeToDiscipline> GroupeToDisciplines { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
