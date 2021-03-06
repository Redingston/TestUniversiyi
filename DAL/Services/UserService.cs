﻿using DAL.Entities;
using DAL.Helpers;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class UserService: IUserService
    {
        private readonly IAppDbContext _context;

        public UserService(IAppDbContext context)
        {
            _context = context;
        }

        private async Task<bool> CheckEmailAsync(string email) =>
            await _context.Users.AnyAsync(u => u.Email == email);

        private async Task<bool> CheckPhoneNumberAsync(string phoneNumber) =>
            await _context.Users.AnyAsync(u => u.PhoneNumber == phoneNumber);
        public async Task<IDictionary<string, string>> CheckFailuresAsync(string email, string phoneNumber)
        {
            IDictionary<string, string> failures = new Dictionary<string, string>();

            bool emailExists = await CheckEmailAsync(email);
            bool phoneNumberExists = await CheckPhoneNumberAsync(phoneNumber);

            if (emailExists)
            {
                failures.Add("email", "user with this email already exists");
            }

            if (phoneNumberExists)
            {
                failures.Add("phoneNumber", "user with this phone number already exists");
            }

            return failures;
        }

        public async Task<User> CreateUser(UserPartial userPartial, string password, long roleId, long universityId)
        {
            PasswordHash hash = new PasswordHash(password);
            string hashedPassword = Convert.ToBase64String(hash.ToArray());

            User user = new User
            {
                FirstName = userPartial.FirstName,
                Surname = userPartial.Surname,
                PhoneNumber = userPartial.PhoneNumber,
                Email = userPartial.Email,
                Password = hashedPassword,
                DateOfBirth = userPartial.DateOfBirthday,
                RoleId = roleId,
                UniversityId = universityId
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return await _context.Users.FindAsync(user.Id);
        }
    }
}
