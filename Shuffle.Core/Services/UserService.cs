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
        public User GetUser(string authId)
        {
            var user = _db.Users.Where(x => x.AuthId == authId).ProjectTo<User>().FirstOrDefault();

            return user;
        }

        public User GetUserByUsername(string username)
        {
            var user = _db.Users.Where(x => x.Email == username).ProjectTo<User>().FirstOrDefault();

            return user;
        }

        public List<User> GetUsers(string excludedAuthId)
        {
            var query = _db.Users;

            if(!string.IsNullOrEmpty(excludedAuthId))
            {
               var otherUsers = query.Where(x => x.AuthId != excludedAuthId);
                return otherUsers.ProjectTo<User>().ToList();
            }
               

            return query.ProjectTo<User>().ToList();
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

        public User UpdateUser(string authId, User user)
        {
            var userUpdate = _db.Users.Where(x => x.AuthId == authId).FirstOrDefault();

            userUpdate.Name = user.Name;
            userUpdate.Email = user.Email;

            _db.Users.Update(userUpdate);
            _db.SaveChanges();

            return new User
            {
                Id = userUpdate.Id,
                Name = userUpdate.Name,
                Email = userUpdate.Email,
                AuthId = userUpdate.AuthId
            };
        }
    }
}