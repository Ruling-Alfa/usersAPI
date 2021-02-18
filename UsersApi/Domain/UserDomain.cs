using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersApi.Persistance;
using UsersApi.ViewModel;

namespace UsersApi.Domain
{
    public class UserDomain : IUserDomain
    {
        private readonly IUserRepository _userRepository;
        public UserDomain(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<List<User>> GetAllUser()
        {
            return _userRepository.GetAllUser();
        }

        public Task<User> GetUser(int id)
        {
            return _userRepository.GetUser(id);
        }

        public Task<User> AddUser(User user)
        {
            return _userRepository.AddUser(user);
        }

        public Task<User> UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }

        public Task DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }
    }
}
