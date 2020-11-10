using DAL.Entities;
using DAL.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Persistence.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(e => e.Surname)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(e => e.ImageUrl)
                .IsRequired()
                .HasDefaultValue("../../../assets/images/default-user-image.jpg");

            builder.HasOne(e => e.Student)
                .WithOne(e => e.User);

            builder.HasOne(e => e.Teacher)
                .WithOne(e => e.User);

            builder.HasOne(e => e.Role)
                .WithMany(e => e.Users)
                .HasForeignKey(e => e.RoleId);

            builder.HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Nataliya",
                    Surname = "Petrova",
                    PhoneNumber = "0685701035",
                    Email = "teacher1@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("teacher1").ToArray()),
                    DateOfBirth = new DateTime(1980, 5, 2),
                    RoleId = 2,
                    UniversityId = 1,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 2,
                    FirstName = "Taras",
                    Surname = "Bertosh",
                    PhoneNumber = "0689652005",
                    Email = "teacher2@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("teacher2").ToArray()),
                    DateOfBirth = new DateTime(1971, 1, 22),
                    RoleId = 2,
                    UniversityId = 1,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 3,
                    FirstName = "Nazar",
                    Surname = "Borchik",
                    PhoneNumber = "0665000310",
                    Email = "teacher3@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("teacher3").ToArray()),
                    DateOfBirth = new DateTime(1990, 11, 11),
                    RoleId = 2,
                    UniversityId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 4,
                    FirstName = "Eva",
                    Surname = "Yakovleva",
                    PhoneNumber = "0986969659",
                    Email = "student1@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("student1").ToArray()),
                    DateOfBirth = new DateTime(2014, 9, 18),
                    RoleId = 1,
                    UniversityId = 1,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 5,
                    FirstName = "Petro",
                    Surname = "Golovach",
                    PhoneNumber = "0984578752",
                    Email = "student2@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("student2").ToArray()),
                    DateOfBirth = new DateTime(2014, 1, 1),
                    RoleId = 1,
                    UniversityId = 1,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 6,
                    FirstName = "Oleksandra",
                    Surname = "Geruk",
                    PhoneNumber = "0986969659",
                    Email = "student3@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("student3").ToArray()),
                    DateOfBirth = new DateTime(2014, 9, 18),
                    RoleId = 1,
                    UniversityId = 1,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 7,
                    FirstName = "Anastasya",
                    Surname = "Lubak",
                    PhoneNumber = "098555685",
                    Email = "student4@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("student4").ToArray()),
                    DateOfBirth = new DateTime(2013, 11, 20),
                    RoleId = 1,
                    UniversityId = 1,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 8,
                    FirstName = "Bohdan",
                    Surname = "Pokalchuk",
                    PhoneNumber = "0986969659",
                    Email = "student5@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("student5").ToArray()),
                    DateOfBirth = new DateTime(2014, 8, 23),
                    RoleId = 1,
                    UniversityId = 1,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 9,
                    FirstName = "Maksim",
                    Surname = "Matlah",
                    PhoneNumber = "0974570695",
                    Email = "student6@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("student6").ToArray()),
                    DateOfBirth = new DateTime(2010, 9, 18),
                    RoleId = 1,
                    UniversityId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 10,
                    FirstName = "Eva",
                    Surname = "Yakovleva",
                    PhoneNumber = "0986969659",
                    Email = "student7@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("student7").ToArray()),
                    DateOfBirth = new DateTime(2010, 9, 25),
                    RoleId = 1,
                    UniversityId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 11,
                    FirstName = "Edward",
                    Surname = "Misko",
                    PhoneNumber = "0966907769",
                    Email = "student8@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("student8").ToArray()),
                    DateOfBirth = new DateTime(2010, 7, 7),
                    RoleId = 1,
                    UniversityId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 12,
                    FirstName = "Bill",
                    Surname = "Ogon",
                    PhoneNumber = "0555689477",
                    Email = "student9@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("student9").ToArray()),
                    DateOfBirth = new DateTime(2010, 8, 28),
                    RoleId = 1,
                    UniversityId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 13,
                    FirstName = "Yura",
                    Surname = "Sumko",
                    PhoneNumber = "0986969659",
                    Email = "student10@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("student10").ToArray()),
                    DateOfBirth = new DateTime(2010, 1, 20),
                    RoleId = 1,
                    UniversityId = 2,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 14,
                    FirstName = "Andriy",
                    Surname = "Maleev",
                    PhoneNumber = "096957877",
                    Email = "headassistant1@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("headassistant1").ToArray()),
                    DateOfBirth = new DateTime(1980, 5, 10),
                    RoleId = 4,
                    UniversityId = 1,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 15,
                    FirstName = "Dmytro",
                    Surname = "Yak",
                    PhoneNumber = "096878318",
                    Email = "master1@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("master1").ToArray()),
                    DateOfBirth = new DateTime(2000, 4, 8),
                    RoleId = 5,
                    UniversityId = 1,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 16,
                    FirstName = "Bob",
                    Surname = "Masterovich",
                    PhoneNumber = "096878318",
                    Email = "headmaster1@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("headmaster1").ToArray()),
                    DateOfBirth = new DateTime(1995, 9, 6),
                    RoleId = 6,
                    UniversityId = 1,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                },
                new User
                {
                    Id = 17,
                    FirstName = "Sergey",
                    Surname = "Admen",
                    PhoneNumber = "068969025",
                    Email = "admin1@gmail.com",
                    Password = Convert.ToBase64String(new PasswordHash("admin1_").ToArray()),
                    DateOfBirth = new DateTime(2000, 4, 8),
                    RoleId = 7,
                    UniversityId = null,
                    ImageUrl = "../../../assets/images/default-user-image.jpg"
                }
            );
        }
    }
}
