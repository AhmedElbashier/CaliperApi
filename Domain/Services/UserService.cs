using System.Collections.Generic;
using System.Linq;
using CaliperApi.Domain.Helpers;
using CaliperApi.Domain.Models;
using CaliperApi.Domain.Repositories;

namespace CaliperApi.Domain.Services
{
    public interface IUserService
    {
        User GetUser(int id);
        List<UserDto> GetALl();
        User CreateUser(UserDto UserDto);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;

        public UserService(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;    
        }
        
       
        public User GetUser(int id)
        {
            return _UserRepository.GetUser(id);
        }

        public User CreateUser(UserDto UserDto)
        {
            return _UserRepository.CreateUser(UserDto);
        }
        public List<UserDto> GetALl()
        {
            return _UserRepository.GetAll().Select(_UserRepository.ToUserDto).ToList();
        }

    }
}