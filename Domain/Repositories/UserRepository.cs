using System;
using System.Collections.Generic;
using System.Linq;
using CaliperApi.Domain.Helpers;
using CaliperApi.Domain.Models;

namespace CaliperApi.Domain.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User Find(int id);
        User CreateUser(UserDto UserDto);
        UserDto ToUserDto(User User);
        User GetUser(int id);

    }

    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User Find(int id)
        {
            return _context.Users.Find(id);
        }

        public User CreateUser(UserDto UserDto)
        {   
            var User = ToUser(UserDto);
            _context.Users.Add(User);
            this._context.SaveChanges();
            return User;
        }

        private User ToUser(UserDto UserDto)
        {
            return new User
            {   

                name= UserDto.name,
                username = UserDto.username,
                password= UserDto.password,
                role = UserDto.role,
                
            };
        }

        public UserDto ToUserDto(User User)
        {
            return new UserDto
            {
                id= User.id,
                name= User.name,
                username = User.username,
                password= User.password,
                role = User.role,
            };
        }
        
          public User GetUser(int id)
        {
            return _context.Users.Find(id);
        }
         public List<User> GetALL()
        {
            return _context.Users.ToList();
        }
    }
}