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
            var user = new UserEntity
            {
                Name = userToCreate.Name,
                Email = userToCreate.Email,
                AuthId = userToCreate.AuthId
            };
            _db.Users.Add(user);
            _db.SaveChanges();

            return new User
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                AuthId = user.AuthId
            };
        }
    }
}