﻿using FileManagementApplication.Contexts;
using FileManagementApplication.Interfaces;
using FileManagementApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace FileManagementApplication.Repositories
{
    public class UserRepository: IRepository<string, User>
    {
        private readonly FlightContext _context;
        public UserRepository(FlightContext context)
        {
            _context = context;
        }
        public User Add(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public User Delete(string Key)
        {
            var user = GetById(Key);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return user;
            }
            return null;
        }

        public IList<User> GetAll()
        {
            if (_context.Users.Count() == 0)
                return null;
            return _context.Users.ToList();
        }

        public User GetById(string Key)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == Key);
            return user;
        }

        public User Update(User entity)
        {
            var user = GetById(entity.Username);
            if (user != null)
            {
                _context.Entry<User>(user).State = EntityState.Modified;
                _context.SaveChanges();
                return user;
            }
            return null;
        }
    }

}