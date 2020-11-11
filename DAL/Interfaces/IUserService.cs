using DAL.Entities;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUser(UserPartial user, string password, long roleId, long universityId);
        Task<IDictionary<string, string>> CheckFailuresAsync(string email, string phoneNumber);
    }
}
