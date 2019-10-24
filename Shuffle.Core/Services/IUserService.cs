using Shuffle.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shuffle.Core.Services
{
    public interface IUserService
    {
        List<User> GetUsers(string authId);
        User GetUser(string authId);
        User GetUserByUsername(string username);
        User CreateUser(User userToCreate);
        User UpdateUser(string authId, User user);
    }
}