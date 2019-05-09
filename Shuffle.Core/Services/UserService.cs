using System.Linq;
using System.Collections.Generic;
using AutoMapper.QueryableExtensions;
using Shuffle.Data;
using Shuffle.Data.Entities;
using Shuffle.Core.Models;

namespace Shuffle.Core.Services
{
    public class UserService : IUserService
    {
        private readonly ShuffleDbContext _db;

        public UserService(ShuffleDbContext context)
        {
            _db = context;
        }
        public User GetUser(int userId)
        {
            var user = _db.Users.Where(x => x.Id == userId).ProjectTo<User>().FirstOrDefault();

            return user;
        }

        public List<User> GetUsers()
        {
            var user = _db.Users.ProjectTo<User>().ToList();

            return user;
        }

        public User CreateUser(User userToCreate)
        {
            var newUser = new UserEntity
            {
                FirstName = userToCreate.FirstName,
                LastName = userToCreate.LastName,
                Email = userToCreate.Email,
                Password = userToCreate.Password
            };

            var user = _db.Users.Add(newUser);

            var result = _db.SaveChanges();

            return new User
            {
                FirstName = userToCreate.FirstName,
                LastName = userToCreate.LastName,
                Email = userToCreate.Email,
                Password = userToCreate.Password,
                Id = result
            };
        }
    }
}