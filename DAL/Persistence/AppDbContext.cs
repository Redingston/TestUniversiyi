using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Persistence
{
    public class AppDbContext: DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Groupe> Groupes { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherToDiscipline> TeacherToDisciplines { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Auditorium> Auditoriums { get; set; }
        public DbSet<GroupeToDiscipline> GroupeToDisciplines { get; set; }
        public DbSet<GroupeToStudent> GroupeToStudents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

    }
}
